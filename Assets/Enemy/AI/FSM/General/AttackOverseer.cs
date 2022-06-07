using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackOverseer : Steering
{

    public Transform target;

    [SerializeField] private float attackSpeed;
    private float casting = 0f;
    public GameObject bulletPrefab;

    public GameObject player;

    public Vector3 OldPos;
    public GameObject MinePrefab;

    private bool PlayerColided = false;

    public bool HasAttacked = false;

    private int chance;
    private bool GoBack = false;

    private float CheckCharge;
    private Vector3 ChargeTarget;
    private float missileTimer;
    private bool Increased;
    private float GoBackTimer;
    public Animator an;
    public PlayerMovement health;

    public GameObject CastSpot;

    public override SteeringData GetSteering(SteeringBehaviorBase steeringbase)
    {

        SteeringData steering = new SteeringData();


        if (health.health > 0 && !HasAttacked)
        {

           steering = Attack(steering, steeringbase);
            return steering;
        }
        else
        {
            return steering;
        }


    }

    void Start()
    {
        chance = Random.Range(0, 3);

      
    }


    private SteeringData ChargeCharge(SteeringData steering, SteeringBehaviorBase steeringbase)
    {


        if (missileTimer < attackSpeed)
        {

            missileTimer += Time.deltaTime;
            return steering;

        }
        else
        {
           steering = Charge( steering, steeringbase);
            return steering;
        }
       
    }

    private SteeringData Charge( SteeringData steering, SteeringBehaviorBase steeringbase)
    {
        

        if (GoBack)
        {        
                GoBack = false;
                missileTimer = 0f;
                CheckCharge = 0f;
                GoBackTimer = 0f;
                Increased = false;
                HasAttacked = true;

                chance = Random.Range(0, 3);
                steeringbase.maxAccelaration -= 40;
           
          
            return steering;
        }

        if (CheckCharge < 2f)
        {
            CheckCharge += Time.deltaTime;
            ChargeTarget = target.transform.position;
            if (!Increased)
            {
                steeringbase.maxAccelaration += 40;
                Increased = true;
            }

        }
           
            
           
            steering.linear = Vector3.Normalize(ChargeTarget - transform.position);
            steering.linear *= steeringbase.maxAccelaration;
        

        if (PlayerColided == true && GoBack == false)
        {
            PlayerMovement pm = player.GetComponent<PlayerMovement>();

            if (!pm.blockframes && !pm.dodgeframes)
            {
                player.GetComponent<PlayerMovement>().health -= 30;


                player.GetComponent<Rigidbody>().AddForce(transform.up + transform.forward * 10, ForceMode.Impulse);
            }

            GoBack = true;
        }

        if (GoBackTimer >= 5f)
        {
            GoBack = true;

        }

        GoBackTimer += Time.deltaTime;

        return steering;
    }



    private void ChargeMine()
    {
        casting += Time.deltaTime;


        if (casting > attackSpeed)
        {

            PlaceMine();
        }
    }

    private void PlaceMine()
    {
     
        Vector3 mineLocation = new Vector3(transform.position.x + transform.forward.x * 3, transform.position.y + 0.1f, transform.position.z + transform.forward.z*2);
        Instantiate(MinePrefab, mineLocation, Quaternion.identity);

        chance = Random.Range(0, 3);
        casting = 0;
        HasAttacked = true;

    }


    public void Shoot()
    {
        
        an.Play("Shoot");
        an.SetBool("HasShot", true);
    }

    public void launch()
    {




        GameObject bullet = Instantiate(bulletPrefab, CastSpot.transform.position, Quaternion.identity);

        bullet.GetComponent<Rigidbody>().velocity = Vector3.Normalize(target.position - transform.position) * 30;
      

 


    }

    public void EndAnim()
    {
        HasAttacked = true;
        an.SetBool("HasShot", false);
    }


    public SteeringData Attack(SteeringData steering, SteeringBehaviorBase steeringbase)
    {
            
               
                Shoot();
                    
            
            return steering;
        
    }



    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
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
