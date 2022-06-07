using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMain : MonoBehaviour
{

    public AnimationCurve An;
    public Transform target;
    public bool LevOver = false;

    public int stage;
    private Enemy hp;

    public Transform LevWaypoint; 

    public ChekIfInBossRoom ck;

    public Transform[] TopB;

    public Transform[] RightB;

    public Transform[] LeftB;

    public Transform[] DownB;

    public float LevitateTimer = 0f;

    private Rigidbody rb;
    private Vector3 ip;

    public int RandomAttack;

   

    private float casting;
    public float attackSpeed;

    public GameObject BulletMinigunPrefab;
    public float shootTimeInterval = 2;
    private float shootTimer = 0.01f;
    private int bulletCount = 0;

    public GameObject bulletBossRoom;

    private bool Teleported = false;
    public Transform PlayerWaypoint;
    public Transform BossWaypoint;

    private float turnSmoothVelocity;
    private void Start()
    {
        ip = transform.position;
        rb = GetComponent<Rigidbody>();
        stage = 1;
        hp = GetComponent<Enemy>();
    }
    public void Levitate()
    {
        if(!LevOver)
        {
            Vector3 direction = target.position - transform.position;
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, 0);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            LevitateTimer += Time.deltaTime;
          
            rb.position = Vector3.Lerp(ip, LevWaypoint.position, An.Evaluate(LevitateTimer / 5));

            if (LevitateTimer > 5f)
            {
                rb.useGravity = true;
                LevOver = true;
            }
        }
        
    }

   
    public void DecideAttack()
    {
        //RandomAttack = Random.Range(1, 4);
        if(stage ==1)
        {
            RandomAttack = 1;
        }
        else
        {
            RandomAttack = Random.Range(1, 6);
        }

    }

    public void Attack()
    {
        Vector3 direction = target.position - transform.position;
        float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
        float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, 0);
        transform.rotation = Quaternion.Euler(0f, angle, 0f);

        if (stage == 1)
        {
            if(RandomAttack == 1)
            {
                ChargeMinigun();
                
            }
            else if(RandomAttack == 2)
            {

            }
            else if(RandomAttack == 3)
            {

            }
        }
        else if(stage == 2)
        {
            Debug.Log("here");
            if (RandomAttack == 1)
            {

                ChargeLeftB();
            }
            else if (RandomAttack == 2)
            {
                ChargeDownB();
            }
            else if (RandomAttack == 3)
            {
                ChargeTopB();
            }
            else if (RandomAttack == 4)
            {
                ChargeRightB();
            }
            else if(RandomAttack == 5)
            {
                ChargeAll();
            }
        }
    }

    private void ChargeAll()
    {
        casting += Time.deltaTime;


        if (casting > attackSpeed)
        {

            AllBullets();
        }
    }
    private void ChargeLeftB()
    {
        casting += Time.deltaTime;


        if (casting > attackSpeed)
        {

            LeftBullets();
        }
    }

    private void ChargeRightB()
    {
        casting += Time.deltaTime;


        if (casting > attackSpeed)
        {

            RitghBullets();
        }
    }

    private void ChargeDownB()
    {
        casting += Time.deltaTime;


        if (casting > attackSpeed)
        {

            DownBullets();
        }
    }


    private void ChargeTopB()
    {
        casting += Time.deltaTime;


        if (casting > attackSpeed)
        {

            TopBullets();
        }
    }


    private void AllBullets()
    {
        for (int i = 0; i < LeftB.Length; i++)
        {
            Vector3 bulletPos = LeftB[i].position;

            GameObject bullet = Instantiate(bulletBossRoom, bulletPos + transform.forward, Quaternion.identity);
            bullet.GetComponent<Rigidbody>().velocity = Vector3.Normalize(target.transform.position - bullet.transform.position) * 30;
        }
        for (int i = 0; i < DownB.Length; i++)
        {
            Vector3 bulletPos = DownB[i].position;

            GameObject bullet = Instantiate(bulletBossRoom, bulletPos + transform.forward, Quaternion.identity);
            bullet.GetComponent<Rigidbody>().velocity = Vector3.Normalize(target.transform.position - bullet.transform.position) * 30;
        }
        for (int i = 0; i < RightB.Length; i++)
        {
            Vector3 bulletPos = RightB[i].position;

            GameObject bullet = Instantiate(bulletBossRoom, bulletPos + transform.forward, Quaternion.identity);
            bullet.GetComponent<Rigidbody>().velocity = Vector3.Normalize(target.transform.position - bullet.transform.position) * 30;
        }
        for (int i = 0; i < TopB.Length; i++)
        {
            Vector3 bulletPos = TopB[i].position;

            GameObject bullet = Instantiate(bulletBossRoom, bulletPos + transform.forward, Quaternion.identity);
            bullet.GetComponent<Rigidbody>().velocity = Vector3.Normalize(target.transform.position - bullet.transform.position) * 30;
        }
        casting = 0;
    }

    private void LeftBullets()
    {
        for (int i = 0; i < LeftB.Length; i++)
        {
            Vector3 bulletPos = LeftB[i].position;

            GameObject bullet = Instantiate(bulletBossRoom, bulletPos + transform.forward, Quaternion.identity);
            bullet.GetComponent<Rigidbody>().velocity = Vector3.Normalize(target.transform.position - bullet.transform.position) * 30;
        }
        casting = 0;
    }
    private void DownBullets()
    {
        for (int i = 0; i < DownB.Length; i++)
        {
            Vector3 bulletPos = DownB[i].position;

            GameObject bullet = Instantiate(bulletBossRoom, bulletPos + transform.forward, Quaternion.identity);
            bullet.GetComponent<Rigidbody>().velocity = Vector3.Normalize(target.transform.position - bullet.transform.position) * 30;
        }
        casting = 0;
    }

    private void RitghBullets()
    {
        for (int i = 0; i < RightB.Length; i++)
        {
            Vector3 bulletPos = RightB[i].position;

            GameObject bullet = Instantiate(bulletBossRoom, bulletPos + transform.forward, Quaternion.identity);
            bullet.GetComponent<Rigidbody>().velocity = Vector3.Normalize(target.transform.position - bullet.transform.position) * 30;
        }
        casting = 0;
    }

    private void TopBullets()
    {
        for (int i = 0; i < TopB.Length; i++)
        {
            Vector3 bulletPos = TopB[i].position;

            GameObject bullet = Instantiate(bulletBossRoom, bulletPos + transform.forward, Quaternion.identity);
            bullet.GetComponent<Rigidbody>().velocity = Vector3.Normalize(target.transform.position - bullet.transform.position) * 30;
        }
        casting = 0;
    }

    private void Minigun()
    {
        shootTimer += Time.deltaTime;
        if (shootTimer >= shootTimeInterval)
        {
            Debug.Log("shot");
            bulletCount += 1;
            shootTimer = 0;
            Debug.Log(bulletCount);
            Vector3 bulletPos = new Vector3(transform.position.x + Random.Range(-0.5f,0.5f) ,transform.position.y + Random.Range(-0.5f, 0.5f) + 1,transform.position.z + 1);

           GameObject bullet = Instantiate(BulletMinigunPrefab, bulletPos + transform.forward , Quaternion.identity);
            bullet.GetComponent<Rigidbody>().velocity = Vector3.Normalize(target.position - bullet.transform.position) * 20;

        }

        if(bulletCount == 8 )
        {
            casting = 0;
            bulletCount = 0;
        }

    }

    private void ChargeMinigun()
    {
        casting += Time.deltaTime;

        
        if (casting > attackSpeed)
        {

            Minigun();
        }
    }

    private void Update()
    {
       
        if (hp.health < 251)
        {
            stage = 2;
            if(!Teleported)
            {
                Debug.Log("Teleport");
                Teleport();
                
                Teleported = true;
            }
        }

     
    }

    private void Teleport()
    {
        target.position = PlayerWaypoint.position;

        transform.position = BossWaypoint.position;

    }



}
