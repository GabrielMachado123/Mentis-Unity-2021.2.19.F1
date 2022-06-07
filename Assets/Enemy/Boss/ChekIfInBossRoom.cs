using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChekIfInBossRoom : MonoBehaviour
{

    public bool IsInBossRoom = false;
  
   

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            
            IsInBossRoom = true;
        }
    }
}
