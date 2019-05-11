using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
//using UnityEditor.SceneManagement;
using UnityEngine.AI;


#if UNITY_EDITOR
using UnityEditor;
#endif


namespace eDmitriyAssets.NavmeshLinksGenerator
{
    
    public class NavMeshLinks_AutoPlacer : MonoBehaviour
    {
        #region Variables

        public Transform linkPrefab;
        public float tileWidth = 5f;

        [Header( "OffMeshLinks" )] 
        public float maxJumpHeight = 3f;
        public LayerMask raycastLayerMask = -1;


        [Header( "EdgeNormal" )] public bool invertFacingNormal = false;
        public bool dontAllignYAxis = false;


        //
        List< Vector3 > spawnedLinksPositionsList = new List< Vector3 >();
        private Mesh currMesh;
        private List< Edge > edges = new List< Edge >();

        private float agentRadius = 2;

        #endregion






        #region GridGen

        public void Generate()
        {
            if( linkPrefab == null ) return;
            agentRadius = NavMesh.GetSettingsByIndex( 0 ).agentRadius;

            edges.Clear();
            //spawnedLinksPositionsList.Clear();

            CalcEdges();
            PlaceTiles();


            //#if UNITY_EDITOR
            //if( !Application.isPlaying ) EditorSceneManager.MarkSceneDirty( gameObject.scene );
            //#endif

        }



        public void ClearLinks()
        {
            List< NavMeshLink > navMeshLinkList = GetComponentsInChildren<NavMeshLink> ( ).ToList ( );
            while ( navMeshLinkList.Count > 0 )
            {
                GameObject obj = navMeshLinkList[0].gameObject;
                if ( obj != null ) DestroyImmediate ( obj );
                navMeshLinkList.RemoveAt ( 0 );
            }
        }

        private void PlaceTiles()
        {
            if( edges.Count == 0 ) return;

            ClearLinks();


            foreach ( Edge edge in edges )
            {
                int tilesCountWidth = ( int ) Mathf.Clamp( edge.length / tileWidth, 0, 10000 );
                float heightShift = 0;


                for ( int columnN = 0; columnN < tilesCountWidth; columnN++ ) //every edge length segment
                {
                    Vector3 placePos = Vector3.Lerp(
                                           edge.start,
                                           edge.end,
                                           ( float ) columnN / ( float ) tilesCountWidth //position on edge
                                           + 0.5f / ( float ) tilesCountWidth //shift for half tile width
                                       ) + edge.facingNormal * Vector3.up * heightShift;

                    //spawn
                    CheckPlacePos( placePos, edge.facingNormal );
                }
            }
        }




        bool CheckPlacePos( Vector3 pos, Quaternion normal )
        {
            bool result = false;

            Vector3 startPos = pos + normal * Vector3.forward * agentRadius * 2;
            Vector3 endPos = startPos - Vector3.up * maxJumpHeight * 1.1f;

            //Debug.DrawLine ( pos + Vector3.right * 0.2f, endPos, Color.white, 2 );


            NavMeshHit navMeshHit;
            RaycastHit raycastHit = new RaycastHit();
            if( Physics.Linecast( startPos, endPos, out raycastHit, raycastLayerMask.value,
                QueryTriggerInteraction.Ignore ) )
            {
                if( NavMesh.SamplePosition( raycastHit.point, out navMeshHit, 0.5f, NavMesh.AllAreas ) )
                {
                    //Debug.DrawLine( pos, navMeshHit.position, Color.black, 15 );

                    if( Vector3.Distance( pos, navMeshHit.position ) > 1.1f )
                    {
                        //SPAWN NAVMESH LINKS
                        Transform spawnedTransf = Instantiate(
                            linkPrefab.transform,
                            pos - normal * Vector3.forward * 0.02f,
                            normal
                        ) as Transform;

                        var nmLink = spawnedTransf.GetComponent< NavMeshLink >();
                        nmLink.startPoint = Vector3.zero;
                        nmLink.endPoint = nmLink.transform.InverseTransformPoint( navMeshHit.position );
                        nmLink.UpdateLink();

                        spawnedTransf.SetParent( transform );
                    }
                }
            }

            return result;
        }



        #endregion




        #region EdgeGen


        float triggerAngle = 0.999f;

        private void CalcEdges()
        {
            var tr = NavMesh.CalculateTriangulation();


            currMesh = new Mesh()
            {
                vertices = tr.vertices,
                triangles = tr.indices
            };


            for ( int i = 0; i < currMesh.triangles.Length - 1; i += 3 )
            {
                //CALC FROM MESH OPEN EDGES vertices

                TrisToEdge( currMesh, i, i + 1 );
                TrisToEdge( currMesh, i + 1, i + 2 );
                TrisToEdge( currMesh, i + 2, i );
            }



            foreach ( Edge edge in edges )
            {
                //EDGE LENGTH
                edge.length = Vector3.Distance(
                    edge.start,
                    edge.end 
                );

                //FACING NORMAL 
                if( !edge.facingNormalCalculated )
                {
                    edge.facingNormal = Quaternion.LookRotation( Vector3.Cross( edge.end - edge.start, Vector3.up ) );


                    if( edge.startUp.sqrMagnitude > 0 )
                    {
                        var vect = Vector3.Lerp( edge.endUp, edge.startUp, 0.5f ) -
                                   Vector3.Lerp( edge.end, edge.start, 0.5f );
                        edge.facingNormal = Quaternion.LookRotation( Vector3.Cross( edge.end - edge.start, vect ) );


                        //FIX FOR NORMALs POINTING DIRECT TO UP/DOWN
                        if( Mathf.Abs( Vector3.Dot( Vector3.up, ( edge.facingNormal * Vector3.forward ).normalized ) ) >
                            triggerAngle )
                        {
                            edge.startUp += new Vector3( 0, 0.1f, 0 );
                            vect = Vector3.Lerp( edge.endUp, edge.startUp, 0.5f ) -
                                   Vector3.Lerp( edge.end, edge.start, 0.5f );
                            edge.facingNormal = Quaternion.LookRotation( Vector3.Cross( edge.end - edge.start, vect ) );
                        }
                    }

                    if( dontAllignYAxis )
                    {
                        edge.facingNormal = Quaternion.LookRotation(
                            edge.facingNormal * Vector3.forward,
                            Quaternion.LookRotation( edge.end - edge.start ) * Vector3.up
                        );
                    }

                    edge.facingNormalCalculated = true;
                }
                if( invertFacingNormal ) edge.facingNormal = Quaternion.Euler( Vector3.up * 180 ) * edge.facingNormal;

            }
        }



        private void TrisToEdge( Mesh currMesh, int n1, int n2 )
        {
            Vector3 val1 =  currMesh.vertices[ currMesh.triangles[ n1 ] ] ;
            Vector3 val2 =  currMesh.vertices[ currMesh.triangles[ n2 ] ] ;

            Edge newEdge = new Edge( val1, val2 );

            //remove duplicate edges
            foreach ( Edge edge in edges )
            {
                if( ( edge.start == val1 & edge.end == val2 )
                    || ( edge.start == val2 & edge.end == val1 )
                )
                {
                    //print("Edges duplicate " + newEdge.start + " " + newEdge.end);
                    edges.Remove( edge );
                    return;
                }
            }

            edges.Add( newEdge );
        }

        #endregion
    }



    [Serializable]
    public class Edge
    {
        public Vector3 start;
        public Vector3 end;

        public Vector3 startUp;
        public Vector3 endUp;

        public float length;
        public Quaternion facingNormal;
        public bool facingNormalCalculated = false;


        public Edge( Vector3 startPoint, Vector3 endPoint )
        {
            start = startPoint;
            end = endPoint;
        }
    }





    #if UNITY_EDITOR

    [CustomEditor( typeof( NavMeshLinks_AutoPlacer ) )]
    [CanEditMultipleObjects]
    public class NavMeshLinks_AutoPlacer_Editor : Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            if( GUILayout.Button( "Generate" ) )
            {
                foreach ( var targ in targets )
                {
                    ( ( NavMeshLinks_AutoPlacer ) targ ).Generate();
                }
            }

            if ( GUILayout.Button ( "ClearLinks" ) )
            {
                foreach ( var targ in targets )
                {
                    ( (NavMeshLinks_AutoPlacer)targ ).ClearLinks();
                }
            }
        }
    }

#endif
}