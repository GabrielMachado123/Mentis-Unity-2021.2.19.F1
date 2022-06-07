using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CohesionBehavior : Steering
{
    public Transform[] agents;
    public float viewAngle;
    public float radius;
    public override SteeringData GetSteering(SteeringBehaviorBase steeringbase)
    {
        SteeringData steeringData = new SteeringData();
        Vector3 centerPosition = Vector3.zero;
        int count = 0;

        foreach (Transform agent in agents)
        {
            Vector3 direction = agent.position - transform.position;

            if (direction.magnitude < radius && (Vector3.Angle(direction, transform.forward) < viewAngle))
            {
                centerPosition += agent.position;
                count++;
            }
        }

        if(count > 0)
        {
            centerPosition /= count;
            steeringData.linear = Vector3.Normalize(centerPosition - transform.position);
            steeringData.linear *= steeringbase.maxAccelaration;

        }



        return steeringData;
    }


    private void Start()
    {
        SteeringBehaviorBase[] steeringAgents = FindObjectsOfType<SteeringBehaviorBase>();
        agents = new Transform[steeringAgents.Length - 1];
        int c = 0;
        foreach (SteeringBehaviorBase agent in steeringAgents)
        {
            if (agent.gameObject != gameObject)
            {
                agents[c] = agent.transform;
                c++;

            }
        }
    }
}
