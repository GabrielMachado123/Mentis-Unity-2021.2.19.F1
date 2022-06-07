using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boulder : MonoBehaviour
{
    public PlayerMovement player;
    public Vector3 startpos;
    public Vector3 endpos;
    public AudioSource audio;

    // Start is called before the first frame update
    void Start()
    {
        startpos = transform.position;
        endpos = startpos + player.targetdirection * 50;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position == endpos)
        {
            Destroy(gameObject);
        }
    }

    void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, endpos, 50 * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Enemies")
        {
            Enemy enemy = collision.GetComponent<Enemy>();
            enemy.health -= 40;
            enemy.StartKnockback = true;
            audio.Play();
        }

    }
}
