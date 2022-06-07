using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceWheels : MonoBehaviour
{
    private GameObject player;
    private Rigidbody rb;
    private Vector3 direction;

    public float lifetime;
    private float countdown = 0;
    private float turnSmoothVelocity;
    void Start()
    {

        player = GameObject.FindGameObjectWithTag("Player");
        rb = gameObject.GetComponent<Rigidbody>();

        direction = player.transform.position - transform.position;
        direction = direction.normalized;
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = direction * 65;

        float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
        float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, 0);
        transform.rotation = Quaternion.Euler(0f, angle, 0f);
        countdown += Time.deltaTime;

        if(countdown > lifetime)
        {
            Destroy(gameObject);
        }
        
    }
}
