using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FlyingAgent : MonoBehaviour
{
    public GameObject player;

    public Transform target;

    public NavMeshAgent agent;

    public GameObject Body;

    public Waypoint[] waypoints;

    private int currentWaypointIndex = 0;

    private bool FoundThePlayer = false;

    public bool HasAttacked = false;

    private bool ColRight;
    private bool ColLeft;
    private bool ColFoward;
    private bool ColBack;

    public GameObject MissilePrefab;


    private float GeneralAttCd = 1f;
    private float GeneralAttCdTimer = 0f;

    private float missileTimer = 0f;

    private bool GoBack = false;
    private bool checkFlight = false;
    private Vector3 FlyTarget;
    private float GoBackTimer = 0f;

    private float rdom;

    void Start()
    {
        rdom = Random.Range(0, 1);
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    public void Update()
    {
        if (FoundThePlayer)
        {


            Vector3 pdirection = target.position - Body.transform.position;

            Vector3 newDirection = Vector3.RotateTowards(Body.transform.forward, pdirection, Time.deltaTime, 0.0f);

            Body.transform.rotation = Quaternion.LookRotation(newDirection);
        }

        if (HasAttacked == true)
        {
            GeneralAttCdTimer += Time.deltaTime;
        }
        if (GeneralAttCdTimer >= GeneralAttCd)
        {
            GeneralAttCdTimer = 0;
            HasAttacked = false;
            Debug.Log("its turning false");
        }


    }

    public void Attack()
    {

      

        FoundThePlayer = true;
        
     
        
         if(rdom >= 0.5f)
          {
         Debug.Log("ChargeMissile");
         CastMissile();
         }
         else
         {
         Debug.Log("ChargeFly");
         ChargeFly();
         }
            
       


    }


    private void ChargeFly()
    {
        Debug.Log(missileTimer);
        missileTimer += Time.deltaTime;
        if (missileTimer < 2f)
        {
            Debug.Log(missileTimer);
            missileTimer += Time.deltaTime;
        }
        else
        {
            Fly();
        }
    }

    private void Fly()
    {
        Debug.Log("Fly");

        if(GoBack)
        {
            Debug.Log("GoingBack");
            Body.transform.position = Vector3.MoveTowards(Body.transform.position, new Vector3(transform.position.x,transform.position.y + 4.56f, transform.position.z), 20 * Time.deltaTime);
          

            if (transform.position.x == Body.transform.position.x)
            {
                GoBack = false;
                HasAttacked = true;
                missileTimer = 0f;
                checkFlight = false;
                rdom = Random.Range(0, 1);
            }

        }
        
        if(!checkFlight)
        {
            FlyTarget = target.transform.position;
            checkFlight = true;
        }



        Body.transform.position = Vector3.MoveTowards(Body.transform.position, FlyTarget, 10 * Time.deltaTime);

        if (Body.GetComponent<Body>().PlayerColided == true && GoBack == false)
        {
            player.GetComponent<PlayerMovement>().health -= 20f;
            

          

            GoBack = true;
           
        }

        if(GoBackTimer >= 2)
        {
            GoBack = true;
         
        }

        GoBackTimer += Time.deltaTime;


    }



    private void CastMissile()
    {
        Vector3 pdirection = target.position - Body.transform.position;

        Vector3 newDirection = Vector3.RotateTowards(Body.transform.forward, pdirection, Time.deltaTime, 0.0f);

        Body.transform.rotation = Quaternion.LookRotation(newDirection);

        Debug.Log("2"+missileTimer);
        missileTimer += Time.deltaTime; 
        if(missileTimer < 2f)
        {
            Debug.Log(missileTimer);
            missileTimer += Time.deltaTime;
        }
        else
        {
            SendMissile();
        }
    }

    private void SendMissile()
    {

        Instantiate(MissilePrefab, Body.transform.position + Body.transform.forward + new Vector3(0.2f,0.2f,0), Quaternion.identity);
        Instantiate(MissilePrefab, Body.transform.position + Body.transform.forward + new Vector3(-0.2f, 0.2f, 0), Quaternion.identity);



        rdom = Random.Range(0, 1);
        Debug.Log("MissileSent");
        missileTimer = 0f;
        HasAttacked = true;
    }

    public void GotoNextWaypoint()
    {
        if (!FoundThePlayer)
        {
            agent.SetDestination(waypoints[currentWaypointIndex].transform.position);
            currentWaypointIndex++;
            if (currentWaypointIndex >= waypoints.Length)
            {
                currentWaypointIndex = 0;
            }
        }
        else
        {
            GoToTarget();
            Vector3 pdirection = target.position - Body.transform.position;

            Vector3 newDirection = Vector3.RotateTowards(Body.transform.forward, pdirection, Time.deltaTime, 0.0f);

            Body.transform.rotation = Quaternion.LookRotation(newDirection);
        }

    }

    public bool IsAtDestionation()
    {
        if (!agent.pathPending)
        {
            if (agent.remainingDistance <= agent.stoppingDistance)
            {
                if (!agent.hasPath || agent.velocity.sqrMagnitude == 0)
                {
                    return true;
                }
            }
        }
        return false;
    }


    public void Reposition()
    {
        

        Debug.Log("Reposition");

        if (!ColRight)
        {
            Debug.Log("A");
            transform.RotateAround(target.transform.position, Vector3.up, 5 * Time.deltaTime);
            Body.transform.position = Vector3.MoveTowards(Body.transform.position, new Vector3(transform.position.x, transform.position.y + 4.56f , transform.position.z), 10 * Time.deltaTime);
        }
        else if (!ColLeft)
        {
            Debug.Log("B");
            transform.RotateAround(target.transform.position, Vector3.down, 5 * Time.deltaTime);
            Body.transform.position = Vector3.MoveTowards(Body.transform.position, new Vector3(transform.position.x, transform.position.y + 4.56f, transform.position.z), 10 * Time.deltaTime);
        }
        else if (!ColBack)
        {
            transform.position = target.position - transform.position;
            Body.transform.position = Vector3.MoveTowards(Body.transform.position, new Vector3(transform.position.x, transform.position.y + 4.56f, transform.position.z), 10 * Time.deltaTime);
        }
    }

    private bool CheckRight()
    {
        Vector3 fwd = transform.TransformDirection(Vector3.right);

        if (Physics.Raycast(transform.position, fwd, 3))
            return true;

        return false;
    }

    private bool CheckLeft()
    {
        Vector3 fwd = transform.TransformDirection(Vector3.left);

        if (Physics.Raycast(transform.position, fwd, 3))
            return true;

        return false;
    }

    private bool Checkback()
    {

        Vector3 fwd = transform.TransformDirection(Vector3.back);

        if (Physics.Raycast(transform.position, fwd, 3))
            return true;

        return false;
    }
    private bool CheckFront()
    {

        Vector3 fwd = transform.TransformDirection(Vector3.forward);

        if (Physics.Raycast(transform.position, fwd, 10))
            return true;

        return false;
    }


    void FixedUpdate()
    {
        ColBack = Checkback();
        //ColFoward = CheckFront();
        ColRight = CheckRight();
        ColLeft = CheckLeft();


    }




    public void GoToTarget()
    {
        Vector3 pdirection = target.position - Body.transform.position;

        Vector3 newDirection = Vector3.RotateTowards(Body.transform.forward, pdirection, Time.deltaTime, 0.0f);

        Body.transform.rotation = Quaternion.LookRotation(newDirection);

        if(Body.transform.rotation == Quaternion.LookRotation(newDirection))
        {
            agent.SetDestination(target.position);
        }
        
    }

    public void Stop()
    {
        agent.isStopped = true;
        agent.ResetPath();
    }


}
