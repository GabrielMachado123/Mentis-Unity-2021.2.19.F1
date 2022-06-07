using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    public Waypoint[] edges;
    private void OnDrawGizmos()
    {
        
        if(edges != null)
        { 
        foreach (Waypoint wp in edges)
        {
            if (wp)
                {
                    
                    Gizmos.color = Color.green;
                    Gizmos.DrawLine(transform.position, wp.gameObject.transform.position);
                }
            }
        }
    }
}
