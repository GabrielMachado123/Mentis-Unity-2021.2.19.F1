using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaffCollision : MonoBehaviour
{
    public PlayerMovement player;
    public AudioSource audio;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.tag == "Enemies" && player.attackframes)
        {
            Enemy enemy = collision.GetComponent<Enemy>();

            if (!enemy.framehit)
            {
                enemy.framehit = true;
                enemy.health -= 20;
                enemy.StartKnockback = true;
                audio.Play();
            }
        }

    }


}
