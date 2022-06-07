using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StayFlying : Steering
{

    [SerializeField] private LayerMask obstacleLayer;
    [SerializeField] private float flyHigh;
    [SerializeField] private float MaxHigh;

    public AttackPlayer att;
    private Vector3 AngleToVector3(float angle)
    {
        return new Vector3(Mathf.Cos(angle), 0, Mathf.Sin(angle));
    }

    public override SteeringData GetSteering(SteeringBehaviorBase steeringbase)
    {
        SteeringData steering = new SteeringData();
      

        Vector3 down = transform.TransformDirection(Vector3.down);
            RaycastHit hit;
        if (Physics.Raycast(transform.position, down, out hit, flyHigh + 1,obstacleLayer) && att.IsAttacking == false)
        {
        
            Vector3 target = hit.point + (hit.normal * flyHigh);
            steering.linear.y = target.y - transform.position.y;
            steering.linear.Normalize();
            steering.linear.y *= steeringbase.maxAccelaration;
           
        }
        
        if(transform.position.y > MaxHigh )
        {
            Vector3 target = Vector3.down;
            steering.linear.y = target.y - transform.position.y;
            steering.linear.Normalize();
            steering.linear.y *= steeringbase.maxAccelaration;
        }


        

        return steering;

    }

    private void Start()
    {
        att = GetComponent<AttackPlayer>();
    }
}
