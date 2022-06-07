using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFollowing : Steering
{
    public PathLine path;
    private float currentParam = 0f;
    public float pathOffset;
    private Vector3 futurepos = Vector3.zero;
    private float maxPrediction; 
    public override SteeringData GetSteering(SteeringBehaviorBase steeringbase)
    {
        SteeringData steering = new SteeringData();
        Vector3 targetPosition;
        if(path.nodes.Length == 1)
        {
            targetPosition = path.nodes[0];
        }
        else
        {
          

            currentParam = path.GetParam(transform.position);
            float targetParam = currentParam + pathOffset;
            targetPosition = path.GetPosition(targetParam);

            Debug.DrawLine(transform.position, targetPosition);

            steering.linear = Vector3.Normalize(targetPosition - transform.position);
            steering.linear *= steeringbase.maxAccelaration;
            
        }
        return steering;
    }
}
