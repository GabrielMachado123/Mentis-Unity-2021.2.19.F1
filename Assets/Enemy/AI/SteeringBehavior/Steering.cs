using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Steering  : MonoBehaviour
{

    public float weight = 1;
 
    public abstract SteeringData GetSteering(SteeringBehaviorBase steeringbase);


}
