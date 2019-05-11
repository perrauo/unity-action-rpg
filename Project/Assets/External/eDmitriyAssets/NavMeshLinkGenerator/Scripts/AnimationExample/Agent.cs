using UnityEngine;
using UnityEngine.AI;


public class Agent : MonoBehaviour {

    #region Variables

    NavMeshAgent navMeshAgent;
    Animator animator;
    Locomotion locomotion;

    public float walkRotationSpeed = 300f;
    private Vector2 directions;



    #region LocomotionVARs

    private Vector3 velocity;
    private float targetSpeed;
    private float targetAngle;
    private float agentDestinationDistance = 0;
    private float footRot = 0;
    private int footRotNameHash;

    private int pAimXHashName, pAimZHashName;


    #endregion

    #region OnAnimatorMoveVARs

    private Vector3 matchTargetEndPos;
    private Vector3 matchTargetStartPos;
    private Quaternion matchTargetRot;
    private Quaternion rootRotation;

    private bool isActive = true;
    private float prevJumpTime = 0;


    #endregion
    
    #endregion




	void Start ()
	{
        //mainCamera = Camera.main.transform;
		navMeshAgent = GetComponent<NavMeshAgent>();
		navMeshAgent.updateRotation = false;
	    navMeshAgent.autoTraverseOffMeshLink = false;

		animator = GetComponent<Animator>();
	    footRotNameHash = Animator.StringToHash ( "footRot" );
        pAimXHashName = Animator.StringToHash ( "PAimX" );
	    pAimZHashName = Animator.StringToHash ( "PAimZ" );


		locomotion = new Locomotion(animator);
	}

    



    #region UpdateAnimDirections

    private void Update()
    {
        SetupAgentLocomotion ( );
        CheckOffmeshLink ( );
        
    }




    //SETUP LOCOMOTION
    protected void SetupAgentLocomotion()
    {
        targetSpeed = navMeshAgent.desiredVelocity.magnitude;
        targetSpeed = navMeshAgent.pathPending ? 0 : targetSpeed;
        targetSpeed = Mathf.Min(targetSpeed, 5);

        Quaternion rotTemp = Quaternion.Inverse(transform.rotation);
        velocity = rotTemp*navMeshAgent.desiredVelocity;
        targetAngle = Mathf.Atan2 ( velocity.x, velocity.z ) * 180.0f / 3.14159f;
        

        locomotion.Do(targetSpeed, targetAngle);
        StrafeMovement( 1/*0.25f*/ );
    }



    private void StrafeMovement(float lerpSpeed = 0.05f)
    {
        footRot = animator.GetFloat ( footRotNameHash );
        if ( footRot > 0 )
        {
            transform.rotation = Quaternion.RotateTowards(
                transform.rotation,
                animator.targetRotation*Quaternion.AngleAxis(targetAngle, Vector3.up),
                footRot * Time.deltaTime * walkRotationSpeed
                );
        }
        velocity = velocity.normalized;
        directions = Vector2.Lerp(
            directions,
            new Vector2(velocity.x, velocity.z)*targetSpeed,
            lerpSpeed
            );

        //Debug.DrawRay( transform.position + transform.rotation * ( velocity), Vector3.up*2, Color.white, 1 );
        float lerpVal = 0.15f;

        animator.SetFloat ( pAimXHashName, directions.x, lerpVal, Time.deltaTime );
        animator.SetFloat ( pAimZHashName, directions.y, lerpVal, Time.deltaTime );
    }



    #endregion


    #region AnimatorMoveAndIK

    //ON ANIMATOR MOVE
    private void OnAnimatorMove ()
    {
        if ( !isActive ) return;


        if ( matchTargetEndPos == Vector3.zero )
        {
            rootRotation = animator.rootRotation;
            rootRotation = new Quaternion ( 0, rootRotation.y, 0, rootRotation.w );
            transform.rotation = rootRotation;

            if ( !navMeshAgent.updatePosition )
            {
                transform.position = animator.rootPosition;
            }

        }
        else
        {
            float matchStart = animator.GetFloat ( "MatchStart" );
            if ( matchStart > 0 )
            {
                //print("Agent match target");

                animator.MatchTarget (
                    matchTargetEndPos,
                    matchTargetRot,
                    CalcAvatarTarget ( animator.GetFloat ( "MatchingLimbN" ) ),
                    new MatchTargetWeightMask ( Vector3.one, 1f ),
                    animator.GetFloat ( "MatchStart" ),
                    animator.GetFloat ( "MatchEnd" )
                    );
                transform.position = animator.rootPosition;
                rootRotation = new Quaternion ( 0, animator.rootRotation.y, 0, animator.rootRotation.w );

                transform.rotation = rootRotation;
            }

        }
        if ( animator.deltaPosition.sqrMagnitude > 0 ) navMeshAgent.velocity = animator.deltaPosition / Time.deltaTime;

    }

    private AvatarTarget CalcAvatarTarget ( float val )
    {
        int n = Mathf.RoundToInt ( val * 10 );
        switch ( n )
        {
            case 1:
                return AvatarTarget.Body;

            case 2:
                return AvatarTarget.LeftFoot;

            case 3:
                return AvatarTarget.LeftHand;

            case 4:
                return AvatarTarget.RightFoot;

            case 5:
                return AvatarTarget.RightHand;

            case 6:
                return AvatarTarget.Root;
            /*case default:
                return AvatarTarget.Root;*/
        }
        return AvatarTarget.Root;
    }


    #endregion

    

    #region OffMeshLink


    private void CheckOffmeshLink ()
    {
        //IF ON OFF-MeshLink
        if ( navMeshAgent != null && navMeshAgent.isOnOffMeshLink && navMeshAgent.updatePosition )
        {
            matchTargetEndPos = navMeshAgent.currentOffMeshLinkData.endPos;
            matchTargetStartPos = navMeshAgent.currentOffMeshLinkData.startPos;

            matchTargetRot = Quaternion.LookRotation (
                ( matchTargetEndPos + Vector3.up * ( matchTargetStartPos.y - matchTargetEndPos.y ) )
                - matchTargetStartPos
                );


            var link = navMeshAgent.navMeshOwner as NavMeshLink;
            if ( link && !animator.GetCurrentAnimatorStateInfo( 0 ).IsTag( "OffMesh" ))
            {
                var linkCast = (NavMeshLink_TBS)link;
                string offMeshLinkAnimName = linkCast.GetAnimName( transform.position );

                navMeshAgent.ActivateCurrentOffMeshLink ( false );
                navMeshAgent.obstacleAvoidanceType = ObstacleAvoidanceType.NoObstacleAvoidance;
                transform.rotation = matchTargetRot;
                
                animator.Play( offMeshLinkAnimName );
            }
            //locomotion.Do ( 0, 0 );
        }
    }


    public void CompleteOffMeshLink ()
    {
        matchTargetEndPos = Vector3.zero;

        if ( navMeshAgent.enabled && navMeshAgent.isOnNavMesh )
        {
            navMeshAgent.ActivateCurrentOffMeshLink ( true );

            navMeshAgent.CompleteOffMeshLink ( );
            navMeshAgent.isStopped = false;

            navMeshAgent.obstacleAvoidanceType = ObstacleAvoidanceType.HighQualityObstacleAvoidance;
        }

    }


    #endregion

}