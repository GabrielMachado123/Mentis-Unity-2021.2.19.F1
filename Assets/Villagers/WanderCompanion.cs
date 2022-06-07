using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderCompanion : Steering
{
    public float wanderRadius;
    public float wanderRate;
    public float wanderOffset;
    private Vector3 InitialPlace;
    [SerializeField] private float MaxWanderDistance;


    private float wanderOrientation = 0;

    private Vector3 AngleToVector3(float angle)
    {
        return new Vector3(Mathf.Cos(angle), 0, Mathf.Sin(angle));
    }

    private void Start()
    {
        InitialPlace = transform.position;
    }


    public override SteeringData GetSteering(SteeringBehaviorBase steeringbase)
    {
        SteeringData steering = new SteeringData();

        float distance = Vector3.Distance(InitialPlace, transform.position);
        
        if (distance < MaxWanderDistance)
        {
            wanderOrientation += (Random.value - Random.value) * wanderRate;
            float agentOrientation = transform.rotation.eulerAngles.y * Mathf.Deg2Rad;
            float targetOrientation = agentOrientation + wanderOrientation;
            Vector3 targetPosition = transform.position + (wanderOffset * AngleToVector3(agentOrientation));
            targetPosition += wanderRadius * AngleToVector3(targetOrientation);

            steering.linear = Vector3.Normalize(targetPosition - transform.position);
            steering.linear *= steeringbase.maxAccelaration;
            return steering;
        }
        else
        {
            steering.linear = Vector3.Normalize(InitialPlace - transform.position);
            steering.linear *= steeringbase.maxAccelaration;
            return steering;
        }




    }
}
