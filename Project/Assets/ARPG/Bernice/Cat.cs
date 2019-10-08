using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.AI;

namespace Cirrus.Bernice
{
    public class Cat : MonoBehaviour
    {
        //[SerializeField]
        //private NavMeshSurface navmeshSurface;

        [SerializeField]
        private NavMeshAgent navmeshAgent;


        public void OnValidate()
        {
            if (navmeshAgent == null)
                navmeshAgent = GetComponent<NavMeshAgent>();


            //if (navmeshSurface == null)
            //    navmeshSurface = FindObjectOfType<NavMeshSurface>();
        }

        private float time;

        [SerializeField]
        private float timeLimit = 2f;


        [SerializeField]
        private float distanceWalk = 10f;


        public void Awake()
        {

        
        }

        //public void F

        public bool RandomPoint(Vector3 center, float range, out Vector3 result)
        {
            for (int i = 0; i < 100; i++)
            {
                Vector2 circle = Random.insideUnitCircle * range;
                Vector3 randomPoint = center + new Vector3(circle.x, 0, circle.y);
                NavMeshHit hit;

                if (NavMesh.SamplePosition(randomPoint, out hit, 4.0f, NavMesh.AllAreas))
                {
                    result = hit.position;
                    return true;
                }
            }
            result = Vector3.zero;
            return false;
        }


        // Update is called once per frame
        public void Update()
        {

            if (time >= timeLimit)
            {
                time = 0;
                RandomPoint(transform.position, distanceWalk, out Vector3 result);
                navmeshAgent.SetDestination(result);
            }

            time += Time.deltaTime;           


            if (Input.GetMouseButtonDown(0))
            {            

                if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out RaycastHit hit, 100))
                {
                    navmeshAgent.SetDestination(hit.point);
                }
            }
        }
    }
}
