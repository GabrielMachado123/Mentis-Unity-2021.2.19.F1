using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    private GameObject player;
    private Transform target;
    private PlayerMovement pm;
    private float ExplodeTimer = 0f;

    private Rigidbody missile;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        target = player.GetComponent<Transform>();
        pm = player.GetComponent<PlayerMovement>();

        missile = gameObject.GetComponent<Rigidbody>();
    }

    float friction = 0.985f; 
    float accel = 40.0f;
    public void FixedUpdate()
    {

        


        Vector3 targPos = target.position;

    
        if ((targPos - transform.position).sqrMagnitude > 10)
        {
            targPos += pm.velocity;
         
            targPos += Vector3.up * 1.5f;
        }
      
        Vector3 thrust = (targPos - transform.position).normalized
                          * accel * Time.deltaTime;
        


        missile.velocity = missile.velocity * friction + thrust;
  
        transform.LookAt(transform.position + missile.velocity);
    }

    public void Update()
    {
        ExplodeTimer += Time.deltaTime;
        if(ExplodeTimer >= 5f)
        {
            Destroy(gameObject);
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            PlayerMovement player = collision.gameObject.GetComponent<PlayerMovement>();

            if (!player.blockframes && !player.dodgeframes)
            {
                player.GetComponent<PlayerMovement>().health -= 15;
            }
            Destroy(gameObject);
            
        }
 
    }
}