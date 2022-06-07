using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class evade : Steering
{
    public Transform target;
    public float maxPrediction;

    public override SteeringData GetSteering(SteeringBehaviorBase steeringbase)
    {
        SteeringData steeringData = new SteeringData();
        Vector3 direction = target.position - transform.position;
        float distance = direction.magnitude;

        float targeSpeed = target.GetComponent<Rigidbody>().velocity.magnitude;
        float agentSpeed = GetComponent<Rigidbody>().velocity.magnitude;

        float prediction;
        if (agentSpeed <= distance / maxPrediction)
        {
            prediction = maxPrediction;
        }
        else
        {
            prediction = distance / agentSpeed;
        }


        Vector3 futurePosition = target.position + (target.GetComponent<Rigidbody>().velocity * prediction) * -1;
        steeringData.linear = Vector3.Normalize(transform.position - futurePosition);
        steeringData.linear *= steeringbase.maxAccelaration;

        return steeringData;
    }
}

