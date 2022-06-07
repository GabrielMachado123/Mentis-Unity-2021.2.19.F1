using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeparationBehavior : Steering
{
    private Transform[] agents;
    public float radius;
    public float decayCoefficient;

    public override SteeringData GetSteering(SteeringBehaviorBase steeringbase)
    {
        SteeringData steeringData = new SteeringData();

        foreach (Transform agent in agents)
        {
            Vector3 direction = agent.position - transform.position;
            if(direction.magnitude < radius)
            {
                float Streght = Mathf.Min(decayCoefficient / (direction.sqrMagnitude), steeringbase.maxAccelaration);
                steeringData.linear += direction.normalized * Streght;

            }
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
