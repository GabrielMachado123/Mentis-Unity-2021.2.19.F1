using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeekBehavior : Steering
{
    public Transform target;
    public override SteeringData GetSteering(SteeringBehaviorBase steeringbase) {

        SteeringData steering = new SteeringData();
        steering.linear =Vector3.Normalize(target.position - transform.position);
        steering.linear.Normalize(); 
        steering.linear *= steeringbase.maxAccelaration;
    
        return steering;
    }

}
