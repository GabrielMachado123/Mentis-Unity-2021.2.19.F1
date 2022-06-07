using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchForPlayer : Steering
{
    public Transform target;
  
    public float viewDistance;
    public AttackPlayer att;
    public float health;
    private float maxHP;
    [SerializeField] private float MaxDist;
    public override SteeringData GetSteering(SteeringBehaviorBase steeringbase)
    {

        SteeringData steering = new SteeringData();
        if (steeringbase.FoundPlayer == false)
        {
            Vector3 direction = new Vector3(target.position.x, 0, target.position.z) - new Vector3(transform.position.x, 0, transform.position.z);
            float distance = direction.magnitude;
           
            if ((distance < viewDistance))
            {
             

                steeringbase.FoundPlayer = true;

                if(distance < MaxDist)
                {
                    att.OldPos = transform.position;
                    return steering;
                }
                else
                {
                    steering.linear = Vector3.Normalize(target.position - transform.position);
                    steering.linear.Normalize();
                    steering.linear *= steeringbase.maxAccelaration;
                    return steering;
                }
               
            
            }
            if(maxHP < health)
            {
                    steeringbase.FoundPlayer = true;
            }

        }
        




        return steering;
    }

    public void Start()
    {
        att = GetComponent<AttackPlayer>();
        health = GetComponent<Enemy>().health;
        maxHP = health;
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }
}
