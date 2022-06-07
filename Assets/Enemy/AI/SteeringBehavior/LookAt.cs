using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : Steering
{
    private Transform target;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }
    public override SteeringData GetSteering(SteeringBehaviorBase steeringbase)
    {
        
        SteeringData steering = new SteeringData();


        if(steeringbase.FoundPlayer == true)
        {
            Vector3 direction = Vector3.Normalize(target.transform.position - transform.position);
            float angle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            steering.angular = Mathf.LerpAngle(transform.rotation.eulerAngles.y, angle, steeringbase.maxAngularAccelaration * Time.fixedDeltaTime);
     
        }
        else
        {
            Vector3 direction = Vector3.Normalize(GetComponent<Rigidbody>().velocity);
            float angle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            steering.angular = Mathf.LerpAngle(transform.rotation.eulerAngles.y, angle, steeringbase.maxAngularAccelaration * Time.fixedDeltaTime);
        }


        

        return steering;
    }
}
