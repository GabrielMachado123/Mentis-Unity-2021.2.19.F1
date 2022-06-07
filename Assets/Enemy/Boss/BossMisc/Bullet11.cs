using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet11 : MonoBehaviour
{

    public GameObject explosion;
    



    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            PlayerMovement player = other.GetComponent<PlayerMovement>();

            if (!player.blockframes && !player.dodgeframes)
            {
                other.gameObject.GetComponent<PlayerMovement>().health -= 35;
              
            }


            Instantiate(explosion, gameObject.transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        else if(other.gameObject.tag != "Boss" || other.gameObject.tag != "Enemies")
        {


          Instantiate(explosion, gameObject.transform.position, Quaternion.identity);
         

            Destroy(gameObject);
            

        }


    }

}
