using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtDirection : Steering
{
    
    public override SteeringData GetSteering(SteeringBehaviorBase steeringbase)
    {
        SteeringData steering = new SteeringData();
        Vector3 direction = Vector3.Normalize(GetComponent<Rigidbody>().velocity);
        float angle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
        steering.angular = Mathf.LerpAngle(transform.rotation.eulerAngles.y, angle, steeringbase.maxAngularAccelaration * Time.fixedDeltaTime);
        return steering;
    }
}
