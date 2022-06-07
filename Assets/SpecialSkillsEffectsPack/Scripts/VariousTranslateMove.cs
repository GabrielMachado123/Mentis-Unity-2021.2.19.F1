using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VariousTranslateMove : MonoBehaviour {

    public float m_power;
    public float m_reduceTime;
    public bool m_fowardMove;
    public bool m_rightMove;
    public bool m_upMove;
    public float m_changedFactor;
    float m_Time;
    public float Life_Time;
    public float countdown = 0f;

    private GameObject player;
    private Rigidbody rb;

    private Vector3 direction;
    void Start()
    {
        m_Time = Time.time;

        player = GameObject.FindGameObjectWithTag("Player");
        rb = gameObject.GetComponent<Rigidbody>();

        direction = player.transform.position = transform.position;
        direction = direction.normalized;

    }

    void Update () {
        
        m_changedFactor = VariousEffectsScene.m_gaph_scenesizefactor;

        if (m_fowardMove)
            transform.Translate(transform.forward * m_power * m_changedFactor);

        if (m_rightMove)
            transform.Translate(transform.right * m_power * m_changedFactor);
        if (m_upMove)
            transform.Translate(transform.up * m_power * m_changedFactor);
        //transform.LookAt(Vector3.zero);



        //rb.velocity = direction * 10;



        countdown += Time.deltaTime;

        if (m_Time + m_reduceTime < Time.time && m_reduceTime != 0)
        {
            m_power -= Time.deltaTime/10;
            m_power = Mathf.Clamp01(m_power);
        }


        if(Life_Time < countdown )
        {
            Destroy(gameObject);
        }
    }
}
