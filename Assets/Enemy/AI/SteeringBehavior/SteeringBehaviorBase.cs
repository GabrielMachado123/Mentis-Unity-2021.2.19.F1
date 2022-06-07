using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteeringBehaviorBase : MonoBehaviour
{
    public float maxAccelaration;
    public float maxAngularAccelaration;
    public float drag;
    public bool FoundPlayer = false;
    private Rigidbody rb;
    private Steering[] steerings;
    private Enemy enemy;

    private bool KnockBack = false;
    private Vector3 Ip;
    private Vector3 Fp;
    private float TimerForKnock = 0f;
    [SerializeField]private AnimationCurve An;

    public PlayerMovement PM;
    

    // Start is called before the first frame update
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        steerings = GetComponents<Steering>();
        rb.drag = drag;
        enemy = GetComponent<Enemy>();
        PM = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();

    }


    
    void FixedUpdate()
    {
        if(enemy != null)
        {
            if (!enemy.StartKnockback && !KnockBack)
            {
              
                FixedSteeering();
            }
            else
            {
                KnockFixed();
            }

        }
        else
        {
            FixedSteeering();
        }
     

    }

    private void FixedSteeering()
    {
        Vector3 accelaration = Vector3.zero;
        float rotation = 0;

        foreach (Steering behavior in steerings)
        {
            behavior.GetSteering(this);
            SteeringData steeringData = behavior.GetSteering(this);
            accelaration += steeringData.linear * behavior.weight;
            rotation += steeringData.angular * behavior.weight;
        }
        if (accelaration.magnitude > maxAccelaration)
        {
            accelaration.Normalize();
            accelaration *= maxAccelaration;
        }
        //if(rotation > maxAngularAccelaration)
        //{
        //   rotation = maxAngularAccelaration;
        //}

        rb.AddForce(accelaration);
        if (rotation != 0)
        {
            rb.rotation = Quaternion.Euler(0, rotation, 0);
        }
    }

    private void Update()
    {
        if(enemy != null)
        {
            if (enemy.StartKnockback || KnockBack)
            {
                KnockUpdate();
            }
        }
    
    }

    private void KnockUpdate()
    {
        if (enemy.StartKnockback)
        {

            Ip = transform.position;
            Fp = new Vector3(PM.targetdirection.x * 3 + transform.position.x, transform.position.y, PM.targetdirection.z * 3 + transform.position.z);

            enemy.StartKnockback = false;
            TimerForKnock = 0f;
            KnockBack = true;
            Debug.Log("Attacked");
        }

        if (TimerForKnock < 1f && KnockBack == true)
        {
            
            TimerForKnock += Time.deltaTime;
        }
        else
        {
            KnockBack = false;
            Ip = Vector3.zero;
            Fp = Vector3.zero;
        }

    }
    private void KnockFixed()
    {
    

        if(TimerForKnock < 1f && KnockBack == true)
        {
            transform.position = Vector3.Lerp(Ip, Fp , An.Evaluate(TimerForKnock));

        }

        
        
    }


}
