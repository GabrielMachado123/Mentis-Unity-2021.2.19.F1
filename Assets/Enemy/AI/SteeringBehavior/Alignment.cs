using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alignment : Steering
{
    private Transform[] agents;

    public float alignmentRadius;

    
   
    public override SteeringData GetSteering(SteeringBehaviorBase steeringbase)
    {
        SteeringData steering = new SteeringData();
        Vector3 sumDirections = Vector3.zero;
        int count = 0;
        foreach (Transform agent in agents)
        {
            if(Vector3.Distance(transform.position, agent.position) < alignmentRadius)
            {
                sumDirections += agent.GetComponent<Rigidbody>().velocity;
                count++;
            }
        }
        if(count > 0)
        {
            sumDirections /= count;

            steering.linear = Vector3.Normalize(sumDirections);
            steering.linear *= steeringbase.maxAccelaration;
        }


        return steering;
    }

    private void Start()
    {
        SteeringBehaviorBase[] steeringAgents = FindObjectsOfType<SteeringBehaviorBase>();
        agents = new Transform[steeringAgents.Length - 1];
        int c = 0;
        foreach(SteeringBehaviorBase agent in steeringAgents)
        {
            if(agent.gameObject != gameObject)
            {
                agents[c] = agent.transform;
                c++;

            }
        }
    }
}
