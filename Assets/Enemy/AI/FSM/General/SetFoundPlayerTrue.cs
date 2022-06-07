using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetFoundPlayerTrue : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<SteeringBehaviorBase>().FoundPlayer = true;    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
