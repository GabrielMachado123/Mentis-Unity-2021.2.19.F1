using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Patrol : MonoBehaviour
{
    public Transform target;

    private NavMeshAgent agent;

    public Waypoint[] waypoints;
    public Reposition rep;
    private int currentWaypointIndex = 0;


    public GameObject player; 

    private float RepositionTimer;
    [SerializeField] private float MaxRepTime;
    void Start()
    {
     
        agent = GetComponent<NavMeshAgent>();      
    }

    public void GotoNextWaypoint()
    {  
        
            agent.SetDestination(waypoints[currentWaypointIndex].transform.position);
            currentWaypointIndex++;
            if (currentWaypointIndex >= waypoints.Length)
            {
                currentWaypointIndex = 0;
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

    public void GoToTarget()
    {
        agent.SetDestination(target.position);
    }

    public void Stop()
    {
        agent.isStopped = true;
        agent.ResetPath();
    }



   public void SetFoundPlayer(int v)
    {
        if(v == 1)
        {
            gameObject.GetComponent<SteeringBehaviorBase>().FoundPlayer = true;
        }
        else
        {
            gameObject.GetComponent<SteeringBehaviorBase>().FoundPlayer = false;
        }
    }

    public void Reposition()
    {

        if (RepositionTimer < MaxRepTime)
        {
            RepositionTimer += Time.deltaTime;
            Debug.Log(rep);
            rep.active = true;
        }
        else
        {
            gameObject.GetComponent<Reposition>().active = false;
            gameObject.GetComponent<AttackOverseer>().HasAttacked = false;
            RepositionTimer = 0;
        }

    }

 

 

   
    public void Attack()
    {
      
    }



}
