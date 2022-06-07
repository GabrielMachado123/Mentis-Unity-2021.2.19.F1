using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArriveBehavior : Steering
{
    public Transform target;
    public float StopRadius;
    public float SlowRadius;

    public override SteeringData GetSteering(SteeringBehaviorBase steeringbase)
    {
        SteeringData steering = new SteeringData();
        Vector3 direction = target.position - transform.position;
        float distance = direction.magnitude;

        if(distance < StopRadius)
        {
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            return steering;
        }
        float speed;
        if (distance < SlowRadius)
        {
            speed = steeringbase.maxAccelaration * (distance / SlowRadius);
        }
        else
        {
            speed = steeringbase.maxAccelaration;
        }
        steering.linear = (direction.normalized * speed) - GetComponent<Rigidbody>().velocity;
   

        return steering;
    }

}
