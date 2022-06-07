using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PullPlayer : MonoBehaviour
{
    private GameObject player;
    private CharacterController Ccont;

    private float Countdown = 0;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        Ccont = player.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float dist = Vector3.Distance(player.transform.position, transform.position);


        

        if (dist < 20 )
        {
            Vector3 pulldirection = (transform.position - player.transform.position).normalized;
            Ccont.SimpleMove(pulldirection * 10);
        }


        Countdown += Time.deltaTime;
        if(Countdown > 8)
        {
            Destroy(gameObject);
        }

    }
}
