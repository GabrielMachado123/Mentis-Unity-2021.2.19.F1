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
        audio.volume = player.master.Svolume;
    }

    private void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.tag == "Enemies" || collision.gameObject.tag == "Boss" || collision.gameObject.tag == "Boss2" && player.attackframes)
        {
            Enemy enemy = collision.GetComponent<Enemy>();

            if (!enemy.framehit)
            {
                enemy.framehit = true;
                enemy.StartKnockback = true;
                audio.Play();
                if (!player.overcharge)
                    enemy.health -= 20;
                else
                    enemy.health -= 40;

                if(!player.overcharge && player.overchargeVal < 100)
                {
                    if(player.manaRecharge)
                        player.overchargeVal += 10;
                    else
                        player.overchargeVal += 5;

                    if(player.overchargeVal > 100)
                    {
                        player.overchargeVal = 100;
                    }
                }
            }
        }

    }


}
