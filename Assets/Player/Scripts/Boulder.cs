using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boulder : MonoBehaviour
{
    public PlayerMovement player;
    public Rigidbody rigid;
    public Vector3 startpos;
    public float accel = 40.0f;

    public float timer;

    public Vector3 targetvelocity;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        startpos = transform.position;
        timer = 0f;
        rigid.velocity = player.targetdirection * 30;
        if(player.target != null)
        targetvelocity = player.target.GetComponent<Rigidbody>().velocity;
    }

    // Update is called once per frame
    void Update()
    {
        if(timer < 5)
        {
            timer += Time.deltaTime;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void FixedUpdate()
    {
        if(player.target != null)
        {
            Vector3 targPos = player.target.transform.position;


            if ((targPos - transform.position).sqrMagnitude > 10)
            {
                targPos += targetvelocity;

                targPos += Vector3.up * 1.5f;
            }

            Vector3 thrust = (targPos - transform.position).normalized
                              * accel * Time.deltaTime;

            rigid.velocity += thrust;
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Enemies" || collision.gameObject.tag == "Boss" || collision.gameObject.tag == "Boss")
        {
            Enemy enemy = collision.GetComponent<Enemy>();
            enemy.StartKnockback = true;
            Destroy(gameObject);
            if (!player.overcharge)
                enemy.health -= 30;
            else
                enemy.health -= 50;

            if (!player.overcharge && player.overchargeVal < 100)
            {
                if (player.manaRecharge)
                    player.overchargeVal += 10;
                else
                    player.overchargeVal += 5;

                if (player.overchargeVal > 100)
                {
                    player.overchargeVal = 100;
                }
            }
        }

    }
}
