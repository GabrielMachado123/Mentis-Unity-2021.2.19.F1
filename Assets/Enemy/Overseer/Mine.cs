using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : MonoBehaviour
{
    private float ExplosionTime = 5f;
    private float timer = 0;

    private GameObject player;
    public ParticleSystem PS;

    private bool exploded = false;

    private MeshRenderer meshR;


    private bool StartTimer = false;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag( "Player"))
        {
            player = collision.gameObject;       
            StartTimer = true;

        }
    }
    private void Start()
    {
        meshR = GetComponent<MeshRenderer>();
    }



    void Update()
    {
        
        if(StartTimer)
        {
            
            timer += Time.deltaTime;
        }

        if (timer >= ExplosionTime && exploded == false)
        {
         


            float hp = player.GetComponent<PlayerMovement>().health;
            float distance = Vector3.Distance(gameObject.transform.position, player.GetComponent<Transform>().position);
           

            if(distance > 3)
            {
                exploded = true;
                PS.Play();
                meshR.enabled = false;
            }
            else
            {
             
                exploded = true;
                hp -= 1.5f * distance;
            }
            
            player.GetComponent<PlayerMovement>().health = hp;
                   
        }

        if(timer >= ExplosionTime + 5f)
        {
            Destroy(gameObject);
        }

    }
}
