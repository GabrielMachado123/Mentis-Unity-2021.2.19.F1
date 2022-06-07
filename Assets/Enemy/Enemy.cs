using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public PlayerMovement player;
    public int health;
    public bool StartKnockback = false;
    public bool framehit = false;

    public string EnemyType;

    public GameObject DissolveScouter;
    public GameObject DissolveBoss;
    public GameObject DissolveOverseer;
   
    void Update()
    {
        if (!player.enemylist.Contains(this))
        {
            player.enemylist.Add(this);
        }

        if (health <= 0)
        {
            player.enemylist.Remove(this);

            switch( EnemyType)
            {
                case "Scouter" :
                    Instantiate(DissolveScouter, transform.position, Quaternion.identity);
                    Destroy(gameObject);
                    break;
                case "Boss":
                    Instantiate(DissolveBoss, transform.position, Quaternion.identity);
                    Destroy(gameObject);
                    break;
                case "Overseer":
                    Instantiate(DissolveOverseer, transform.position, Quaternion.identity);
                    Destroy(gameObject);
                    break;

            }

          
        }
    }


    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
    }
}
