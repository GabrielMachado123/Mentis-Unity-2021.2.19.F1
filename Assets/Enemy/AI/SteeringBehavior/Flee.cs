using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flee : Steering
{
    public Transform target;
    public override SteeringData GetSteering(SteeringBehaviorBase steeringbase)
    {

        SteeringData steering = new SteeringData();
        steering.linear = Vector3.Normalize(target.position - transform.position) * -1;

        steering.linear.Normalize();
        steering.linear *= steeringbase.maxAccelaration;
        

        return steering;
    }
}
