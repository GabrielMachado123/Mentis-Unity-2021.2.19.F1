using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pursue : Steering
{
    public Transform target;
    public float maxprediction;




    public override SteeringData GetSteering(SteeringBehaviorBase steeringbase)
    {
        SteeringData steering = new SteeringData();
        Vector3 direction = target.transform.position - transform.position;
        float distance = direction.magnitude;
        float agentspeed = GetComponent<Rigidbody>().velocity.magnitude;
    

        float prediction;
        if (agentspeed <= distance/maxprediction)
        {
            prediction = maxprediction;
        }
        else
        {
             prediction = distance / agentspeed;
        }
        Vector3 futurePosition = target.position + (target.GetComponent<Rigidbody>().velocity * prediction);
        steering.linear = Vector3.Normalize(futurePosition - transform.position);
        steering.linear *= steeringbase.maxAccelaration;

        return steering;
    }

}
