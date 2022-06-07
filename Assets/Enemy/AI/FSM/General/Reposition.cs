using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reposition : Steering
{
    public Transform target;
    public bool active = false;
    public override SteeringData GetSteering(SteeringBehaviorBase steeringbase)
    {

        SteeringData steering = new SteeringData();

   
        if(active)
        {
            float distance = Vector3.Distance(target.position, transform.position);
            if (distance < 6)
            {
                steering.linear = Vector3.Normalize(transform.position - target.position);
                steering.linear.Normalize();
                steering.linear *= steeringbase.maxAccelaration;
            }
            else
            {
                steering.linear = Vector3.Normalize(target.position - transform.position);
                steering.linear.Normalize();
                steering.linear *= steeringbase.maxAccelaration;
            }

  
        }
  

        return steering;
        


    }





}
