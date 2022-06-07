using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleBullet : MonoBehaviour
{
    private Material mat;

    private bool trigger = false;
    private float dissolve = 0.037f;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<PlayerMovement>().health -= 15;

            trigger = true;
        }
        else if (other.gameObject.tag != "Enemies")
        {
            trigger = true;
        }

    }
    
    
 
    private void Start()
    {
      

        mat = gameObject.GetComponent<Renderer>().material;
 

    }
    private void Update()
    {
        

        if (trigger)
        {
            mat.SetFloat("Cut off", dissolve );
            dissolve += Time.deltaTime;

            if(dissolve > 0.634f)
            {
                Destroy(gameObject);
            }
        }
    }



}
