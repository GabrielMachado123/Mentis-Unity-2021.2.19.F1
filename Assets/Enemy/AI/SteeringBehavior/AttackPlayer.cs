using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPlayer : Steering
{
    public Transform target;
 
    public GameObject player;
    private PlayerMovement health;
    private float rdom;

    private float missileTimer;
    private bool GoBack = false;
    private Vector3 FlyTarget = Vector3.zero;
    public Vector3 OldPos = Vector3.zero;
    private float CheckFlight;
    private bool PlayerColided = false;
    private bool Increased = false;
    private float GoBackTimer;
    [SerializeField] private float attackSpeed;
    public bool IsAttacking = false;
    private SteeringBehaviorBase st;

    public GameObject MissilePrefab;

    private PlayerMovement pm;
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        target = player.GetComponent<Transform>();

        rdom = Random.Range(-1, 1);
        health = player.GetComponent<PlayerMovement>();
        st = GetComponent<SteeringBehaviorBase>();

        pm = player.GetComponent<PlayerMovement>();
    }

    public override SteeringData GetSteering(SteeringBehaviorBase steeringbase)
    {

        SteeringData steering = new SteeringData();
   

        if (steeringbase.FoundPlayer == true && health.health > 0)
        {
              
                Attack(steering, steeringbase);
                return steering;
        }
        else
        {
            gameObject.GetComponent<Wander>().enabled = true;
            return steering;
        }

  
    }
  

    public void Attack(SteeringData steering, SteeringBehaviorBase steeringbase)
    {
        gameObject.GetComponent<Wander>().enabled = false;
        
        if (rdom >= 0f)
        {
            
            CastMissile();
        }
        else
        {
            
            ChargeFly(steering,steeringbase);
        }

     
    }


    private void CastMissile()
    {
      

       
        if (missileTimer < attackSpeed)
        {

            missileTimer += Time.deltaTime;
        }
        else
        {
           
            SendMissile();
        }
    }

    private void SendMissile()
    {
        Instantiate(MissilePrefab, transform.position + transform.forward + new Vector3(0.2f, 0.2f, 0), Quaternion.identity);
        Instantiate(MissilePrefab, transform.position + transform.forward + new Vector3(-0.2f, 0.2f, 0), Quaternion.identity);



        rdom = Random.Range(-1, 1);
      
        missileTimer = 0f;
        
    }



    private void ChargeFly(SteeringData steering, SteeringBehaviorBase steeringbase)
    {
   

        missileTimer += Time.deltaTime;
        if (missileTimer < attackSpeed)
        {
           
          
            
        }
        else
        {
            Fly(OldPos,steering,steeringbase);
        }
    }

    private void Fly(Vector3 oldPos, SteeringData steering, SteeringBehaviorBase steeringbase)
    {
        IsAttacking = true;

        if (GoBack)
        {
           

            steering.linear = Vector3.Normalize(oldPos - transform.position);
            steering.linear.Normalize();
            steering.linear *= steeringbase.maxAccelaration;

            
           
                GoBack = false;
                missileTimer = 0f;
                CheckFlight = 0f;
                GoBackTimer = 0f;
                Increased = false;
                IsAttacking = false;
                rdom = Random.Range(-1, 1);
               steeringbase.maxAccelaration -= 20;
            return;
        }

        if (CheckFlight < 2f)
        {
            CheckFlight += Time.deltaTime;
            FlyTarget = target.transform.position;
            if (!Increased)
            {
                steeringbase.maxAccelaration += 20;
                Increased = true;
            }

        }

        
        steering.linear = Vector3.Normalize(FlyTarget - transform.position );
        steering.linear.Normalize();
        steering.linear *= steeringbase.maxAccelaration;

        if (PlayerColided == true && GoBack == false)
        {


            if (!pm.blockframes && !pm.dodgeframes)
            {
                pm.health -= 30;
               
            }

          


            GoBack = true;
        }

        if (GoBackTimer >= 5f)
        {
            GoBack = true;

        }

        GoBackTimer += Time.deltaTime;
     

    }
  

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            PlayerColided = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PlayerColided = false;
        }
    }

}
