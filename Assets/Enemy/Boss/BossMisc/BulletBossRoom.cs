using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBossRoom : MonoBehaviour
{
   


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            PlayerMovement player = other.GetComponent<PlayerMovement>();

            if(!player.blockframes && !player.dodgeframes)
            {
                other.gameObject.GetComponent<PlayerMovement>().health -= 20;
            }
        

       
            Destroy(gameObject);
        }
    

    }



  

}
