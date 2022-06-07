using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderLaser1 : MonoBehaviour
{
    private PlayerMovement pm;
    private bool colided;

    public float damage;

    private float tickTimer = 0.5f;
    private float tickRate = 0.5f;
    void Start()
    {
        pm = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            

            
            
             
                colided = true;

            

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {


            colided = false;

        }
    }


    private void Update()
    {
        if(colided)
        {
            if(tickTimer > tickRate)
            {
                pm.health -= damage;
                tickTimer = 0;
            }
            else
            {
                tickTimer += Time.deltaTime;
            }
        }
    }

}
