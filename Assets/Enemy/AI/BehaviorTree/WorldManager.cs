using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public struct WaypointInformation
{
  
    public Transform transform;

}

[System.Serializable]
public struct PlayerInfo
{
    public Transform player;

  
}

[System.Serializable]
public struct BossRoomInfo
{
    
    public ChekIfInBossRoom ck;


}



public class WorldManager : MonoBehaviour
{
    public bool haveCastedBlackHole = false;

    public int stage = 1;
    public BehaviorTreeAgent behaviorTree;

    public WaypointInformation[] waypoint;
    public PlayerInfo p;
    public BossRoomInfo BossRoom;

    public Animator animator;

    public bool HasJumped = false;

    public GameObject CastingSpot;

    public GameObject LaserBeam1;
    public GameObject LaserBeam1Collider;

    public GameObject scouter;
    public GameObject spawnEffect;

    private float repositionTimer = 0;
    private Vector3 w;

    public bool Rep = false;
    public bool moveset = false;
    public bool RunningLev = false;
    public bool LevOver = false;
    private float turnSmoothVelocity;
    public float LevitateTimer = 0f;
    public AnimationCurve An;
    private Rigidbody rb;
    private Vector3 ip;
    public GameObject boss;

    public GameObject FlameArena; 

    public bool animEnded = false;

    public GameObject BulletMinigunPrefab;
    private Enemy bossStat;

    private BoxCollider swordColl;


    private PlayerMovement pm;

    public void Start()
    {

        swordColl = Sword.GetComponent<BoxCollider>();

        pm = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        behaviorTree = boss.GetComponent<BehaviorTreeAgent>();
        bossStat = boss.GetComponent<Enemy>();
        ip = boss.transform.position;
        rb = boss.GetComponent<Rigidbody>();
        animator = boss.GetComponent<Animator>();

        
    }
    public bool IsInBossRoom()
    {
        if (BossRoom.ck.IsInBossRoom)
        {
            return true;
        }
        return false;

    }


    public GameObject blackHolePrefab;
    public GameObject BlackHoleWaypoint;
    private GameObject blackHoleEffect;

    public Suck blackHolecode;
    public void BlackHole()
    {
      if (!haveCastedBlackHole)
        {
            animator.Play("BlackHole");
            animator.SetBool("IsCasting", true);
            Destroy(FireCage);
        }
          
        

        
          
        Vector3 direction = p.player.transform.position - boss.transform.position;
        float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
        float angle = Mathf.SmoothDampAngle(boss.transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, 0);
        boss.transform.rotation = Quaternion.Euler(0f, angle, 0f);
    }

    public void BlackHoleCast()
    {
     

        blackHoleEffect = Instantiate(blackHolePrefab, BlackHoleWaypoint.transform.position, Quaternion.identity);
        blackHolecode = blackHoleEffect.GetComponent<Suck>();
        haveCastedBlackHole = true;
        animator.SetBool("IsCasting", false);
    }





    public void Sword3Combo()
    {
        if (!animEnded)
        {
            animator.Play("Sword3");
            animator.SetBool("IsCasting", true);
            swordColl.enabled = true;
        }


        Vector3 direction = p.player.transform.position - boss.transform.position;
        float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
        float angle = Mathf.SmoothDampAngle(boss.transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, 0);
        boss.transform.rotation = Quaternion.Euler(0f, angle, 0f);
    }


    public void Sowrd3Effect()
    {
        SwordSlashEffect = Instantiate(SwordSlashEffectPrefab, swordCastSpot.transform.position, Quaternion.identity);
    }


    public void Sword3End()
    {

        Destroy(SwordSlashEffect);
        animEnded = true;
        rb.isKinematic = true;
        swordColl.enabled = false;
        animator.SetBool("IsCasting", false);
    }


  




    public GameObject SwordSlashEffectPrefab;
    private GameObject SwordSlashEffect;
  
    public void Sword2Combo()
    {
        if (!animEnded)
        {
            animator.Play("Sword2");
            animator.SetBool("IsCasting", true);
            swordColl.enabled = true;
        }


        Vector3 direction = p.player.transform.position - boss.transform.position;
        float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
        float angle = Mathf.SmoothDampAngle(boss.transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, 0);
        boss.transform.rotation = Quaternion.Euler(0f, angle, 0f);
    }

    public void Sword2Force()
    {
        rb.isKinematic = false;
        Vector3 direction = p.player.transform.position - boss.transform.position;
        rb.AddForce(direction * 40);
    }

    
    public void Sowrd2Effect()
    {
        SwordSlashEffect = Instantiate(SwordSlashEffectPrefab, swordCastSpot.transform.position, Quaternion.identity);
    }

    public void Sowrd2Effect2()
    {
        Destroy(SwordSlashEffect);
        SwordSlashEffect = Instantiate(SwordSlashEffectPrefab, swordCastSpot.transform.position, Quaternion.identity);
    }


    public void Sword2End()
    {
        rb.isKinematic = true;
        animEnded = true;
        Destroy(SwordSlashEffect);
        swordColl.enabled = false;
        animator.SetBool("IsCasting", false);
    }






    public GameObject FireBreathPrefab;
    private GameObject FireBreathEffect;
    private bool HasCastedFireBreath = false;
    public GameObject FireBreathCastSpot;

    public void FireBreath()
    {
        float speed = 0.5f;

        if (!animEnded)
        {
            animator.Play("FireBreath");
            animator.SetBool("IsCasting", true);
        }




        if (HasCastedFireBreath)
        {



            Vector3 targetDirection = p.player.position - boss.transform.position;

            float singleStep = speed * Time.deltaTime;


            Vector3 newDirection = Vector3.RotateTowards(boss.transform.forward, targetDirection, singleStep, 0.0f);

            boss.transform.rotation = Quaternion.LookRotation(newDirection);




            Vector3 targetDirection2 = p.player.position - FireBreathEffect.transform.position;

          


            Vector3 newDirection2 = Vector3.RotateTowards(FireBreathEffect.transform.forward, targetDirection2, singleStep, 0.0f);

            FireBreathEffect.transform.rotation = Quaternion.LookRotation(newDirection2);

        }

    }

    public void FireBreathCast()
    {
       
        HasCastedFireBreath = true;


        FireBreathEffect = Instantiate(FireBreathPrefab, FireBreathCastSpot.transform.position, Quaternion.identity);


        Vector3 point = p.player.position;
        point = transform.TransformPoint(point);

        boss.transform.LookAt(point);
        FireBreathEffect.transform.LookAt(point);



  
    }

    public void EndFireBreath()
    {
        HasCastedFireBreath = false;
        animEnded = true;
        Destroy(FireBreathEffect);
        animator.SetBool("IsCasting", false);
    }


    public GameObject swordCastSpot;
    public GameObject sword1Effectprefab;
    private GameObject sword1effect;
    private bool hitgroundsword1 = false;
    public void BossSwordAtt1()
    {

       
        if(!animEnded)
        {
            swordColl.enabled = true;
            animator.Play("Sword1");
            animator.SetBool("IsCasting", true);
        }





        if(!hitgroundsword1)
        {
            Vector3 direction = p.player.transform.position - boss.transform.position;
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(boss.transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, 0);
            boss.transform.rotation = Quaternion.Euler(0f, angle, 0f);
        }
      
    }


    public void sowrd1EffectCast()
    {
        sword1effect = Instantiate(sword1Effectprefab, swordCastSpot.transform.position, Quaternion.identity);
        hitgroundsword1 = true;
    }

   public void EndBossSword1()
    {
        swordColl.enabled = false;

        hitgroundsword1 = false;
        animEnded = true;
        Destroy(sword1effect);
        animator.SetBool("IsCasting", false);
       
      
    }





    private bool FinishedAproximation = false;
    public bool AlreadySummon = false;
   
    public void BossSummonSword()
    {
   
   
        float dist = Vector3.Distance(boss.transform.position, p.player.position);

        

        if(dist > 25 && FinishedAproximation == false)
        {
            boss.transform.position = Vector3.MoveTowards(boss.transform.position, p.player.position, 20f * Time.deltaTime);
        }
        else if(dist < 15 && FinishedAproximation == false)
        {
            
            Vector3 dir = boss.transform.position - p.player.transform.position;
            boss.transform.position = Vector3.MoveTowards(boss.transform.position, dir * 10, 20f * Time.deltaTime);
        }
        else if (!FinishedAproximation)
        {



                playerSwordSummonAnim();
                animator.SetBool("IsCasting", true);
             
         
        
              
        }
        Vector3 direction = p.player.transform.position - boss.transform.position;
        float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
        float angle = Mathf.SmoothDampAngle(boss.transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, 0);
        boss.transform.rotation = Quaternion.Euler(0f, angle, 0f);
    }

    public void playerSwordSummonAnim()
    {
        FinishedAproximation = true;
        animator.Play("SummonSword");
    }

    public GameObject Sword;
    public GameObject SummonSwordEffectPrefab;
    public GameObject SummonSwordEffect;
    private GameObject FireCage;

   
    public void SummonSword()
    {
        Sword.SetActive(true);
        SummonSwordEffect = Instantiate(SummonSwordEffectPrefab, Sword.transform.position, Quaternion.identity);

        FireCage = Instantiate(FlameArena, boss.transform.position, Quaternion.identity);
    }

    public void DeleteSummonSwordEffect()
    {
        Destroy(SummonSwordEffect); 
    }

    public void EndSwordSummonAnim()
    {
        animator.SetBool("IsCasting", false);
        AlreadySummon = true;
        animEnded = true;
    }

 

    public void Levitate()
    {


        Vector3 direction = p.player.transform.position - boss.transform.position;
        float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
        float angle = Mathf.SmoothDampAngle(boss.transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, 0);
        boss.transform.rotation = Quaternion.Euler(0f, angle, 0f);





        RunningLev = true;

        if (LevitateTimer > 10f)
        {
            LevitateTimer = 0;
            RunningLev = false;
            rb.useGravity = true;
            LevOver = true;
        }


    }
    private void FixedUpdate()
    {
        if(behaviorTree.boss == 1)
        {
            if (moveset)
            {
                if (Rep)
                {
                    RepositionAct();
                }
                else if (RunningLev)
                {
                    LevitateTimer += Time.fixedDeltaTime;
                    rb.position = Vector3.Lerp(ip, waypoint[0].transform.position, An.Evaluate(LevitateTimer / 10));
                }
            }
        }
     

    }

    public GameObject ChargeEletricBarrierPrefab;
    private GameObject ChargeEletricBarrierEffect;
    public GameObject EletricBarrierEffectPrefab;
    private GameObject EletricBarrierEffect;
    private bool HaveEletricarBarrier = false;
    public void EletricBarrier()
    {
        float speed = 12f;

        if (!animEnded)
        {
            animator.Play("NelioMagic");
            animator.SetBool("IsCasting", true);

        }
        


        Vector3 direction = p.player.transform.position - boss.transform.position;
        float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
        float angle = Mathf.SmoothDampAngle(boss.transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, 0);
        boss.transform.rotation = Quaternion.Euler(0f, angle, 0f);


        float dist = Vector3.Distance(boss.transform.position, p.player.position);

        float singleStep = speed * Time.deltaTime;

        if (HaveEletricarBarrier && dist > 1)
        {
            boss.transform.position = Vector3.MoveTowards(boss.transform.position, p.player.transform.position, singleStep);
            EletricBarrierEffect.transform.position = Vector3.MoveTowards(EletricBarrierEffect.transform.position, p.player.transform.position, singleStep);
        }

    }


    public void ChargeEletricBarrier()
    {
        ChargeEletricBarrierEffect = Instantiate(ChargeEletricBarrierPrefab, boss.transform.position, Quaternion.identity);
    }


    public void CastEletricBarrier()
    {
        Destroy(ChargeEletricBarrierEffect);
        EletricBarrierEffect = Instantiate(EletricBarrierEffectPrefab, boss.transform.position, Quaternion.identity);
        HaveEletricarBarrier = true;
    }

    public void EletricBarrierEnd()
    {
        animator.SetBool("IsCasting", false);
        animEnded = true;
        Destroy(EletricBarrierEffect);
        HaveEletricarBarrier = false;
    }






    public void Laser2()
    {
        if (!animEnded)
        {
            animator.Play("magicThrow");
            animator.SetBool("IsCasting", true);
        }



        Vector3 direction = p.player.transform.position - boss.transform.position;
        float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
        float angle = Mathf.SmoothDampAngle(boss.transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, 0);
        boss.transform.rotation = Quaternion.Euler(0f, angle, 0f);
    }

    public GameObject LaserBeam2Prefab;
    public GameObject LaserBeam2CollPrefab;
    public GameObject warningZoneLaser2Prefab;
    private GameObject Laser2Effect;
    private GameObject Laser2Coll;
    private GameObject warningZoneLaser2;


    public void Laser2Warning()
    {
        if(p.player.transform.position.y > 3 )
        {
            warningZoneLaser2 = Instantiate(warningZoneLaser2Prefab, new Vector3(p.player.position.x, 0.6f, p.player.position.z), Quaternion.identity);
        }
        else
        {
            warningZoneLaser2 = Instantiate(warningZoneLaser2Prefab, new Vector3(p.player.position.x, p.player.position.y, p.player.position.z), Quaternion.identity);
        }
        
    }

    public void Laser2Cast()
    {
        Destroy(warningZoneLaser2);

        Laser2Effect = Instantiate(LaserBeam2Prefab, warningZoneLaser2.transform.position, Quaternion.identity);
        Laser2Coll = Instantiate(LaserBeam2CollPrefab, warningZoneLaser2.transform.position, Quaternion.identity);
    
    }

    public void ReseTLaser2()
    {
        Destroy(Laser2Coll);
        Destroy(Laser2Effect);
    }
    



    private GameObject Laser1;
    private GameObject Laser1Collider;
    private Vector3 endPoint;
    public void attack13()
    {
        float speed = 0.55f;
        if (!animEnded)
        {
            animator.Play("LaserRay");
            animator.SetBool("IsCasting", true);
          
        }


        Vector3 targetDirection = p.player.position - boss.transform.position;

        float singleStep = speed * Time.deltaTime;

       
        Vector3 newDirection = Vector3.RotateTowards(boss.transform.forward, targetDirection, singleStep, 0.0f);

    

        boss.transform.rotation = Quaternion.LookRotation(newDirection);

        if(Laser1 != null)
        {


            Vector3 targetDirection2 = p.player.position - Laser1.transform.position;


            Vector3 newDirection2 = Vector3.RotateTowards(Laser1.transform.forward, targetDirection2, singleStep, 0.0f);

            Laser1.transform.rotation = Quaternion.LookRotation(newDirection2);
            Laser1Collider.transform.rotation = Quaternion.LookRotation(newDirection2);

            

        }
    }

    private void attack31CastPhase1()
    {
      
        
            Laser1Collider = Instantiate(LaserBeam1Collider, CastingSpot.transform.position, Quaternion.identity);
            Laser1 = Instantiate(LaserBeam1, CastingSpot.transform.position, Quaternion.identity);

            Vector3 point = p.player.position + (p.player.transform.right * 10) + p.player.transform.up;
            point = transform.TransformPoint(point);

            boss.transform.LookAt(point);
            Laser1.transform.LookAt(point);
            Laser1Collider.transform.LookAt(point);
        
    



    }

    public void attack12()
    {

        if (!animEnded)
        {
            animator.Play("casting2");
            animator.SetBool("IsCasting", true);
        }


        Vector3 direction = p.player.transform.position - boss.transform.position;
        float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
        float angle = Mathf.SmoothDampAngle(boss.transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, 0);
        boss.transform.rotation = Quaternion.Euler(0f, angle, 0f);


    }

    private void attack2CastPhase1()
    {
        Instantiate(spawnEffect, boss.transform.position + new Vector3(0,8,0),Quaternion.identity);
      
    }


    private void attack2CastPhase2()
    {
       GameObject a = Instantiate(scouter, boss.transform.position + new Vector3(0, 8, 0), Quaternion.identity);
    

        a.GetComponent<SteeringBehaviorBase>().FoundPlayer = true;
       
    }

 
    public void attack11()
    {
        if (!animEnded)
        {
            animator.Play("casting1");
            animator.SetBool("IsCasting", true);
        }


        Vector3 direction = p.player.transform.position - boss.transform.position;
        float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
        float angle = Mathf.SmoothDampAngle(boss.transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, 0);
        boss.transform.rotation = Quaternion.Euler(0f, angle, 0f);

    }

    private void Attack1Cast()
    {  
      

        GameObject bullet = Instantiate(BulletMinigunPrefab, CastingSpot.transform.position + boss.transform.forward, Quaternion.identity);
        bullet.GetComponent<Rigidbody>().velocity = Vector3.Normalize(p.player.transform.position - bullet.transform.position + boss.transform.up) * 40;
    }

    private void AttackAnimEnd()
    {
       
        animator.SetBool("IsCasting", false);
        animEnded = true;
       
        
    }

    private void Laser1End()
    {
        animator.SetBool("IsCasting", false);
        animEnded = true;
        Destroy(Laser1);
        Destroy(Laser1Collider);
    }



    public void Reposition()
    {

        Vector3 direction = p.player.transform.position - boss.transform.position;
        float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
        float angle = Mathf.SmoothDampAngle(boss.transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, 0);
        boss.transform.rotation = Quaternion.Euler(0f, angle, 0f);

        if (!Rep)
        {
            
            w = Vector3.zero;
            int i = 0;

            i = Random.Range(0, waypoint.Length); 
            w = waypoint[i].transform.position;
          
            Rep = true;
        }
       

    }

    public void RepositionAct()
    {
        if(!AlreadySummon)
        {
            rb.position = Vector3.MoveTowards(rb.position, w, 6 * Time.fixedDeltaTime);
            repositionTimer += Time.fixedDeltaTime;
        }
       else if(stage == 2)
        {
            float dist = Vector3.Distance(boss.transform.position, p.player.position);
            if(dist > 3)
            {
                rb.position = Vector3.MoveTowards(rb.position, p.player.position, 12 * Time.fixedDeltaTime);
            }
            else
            {
                repositionTimer = 4f;
            }
            
            repositionTimer += Time.fixedDeltaTime;
        }
    }

    public bool isRepover()
    {
        if(repositionTimer > 4f)
        {
            Rep = false;
            repositionTimer = 0;
            return true;
         
        }
        else
        {
            return false;
        }
        
    }

    public float GetHp()
    {
        return bossStat.health;
    }


    public bool ChecklevOver()
    {
        if(!LevOver)
        {
            return false;

        }
        else
        {
            return true;
        }
    }

    public GameObject[] Waypoints2;

    public bool Move2Over = false;

    private bool HasAwaytpoint = false;

    private Vector3 w2 = Vector3.zero;
    private  int i2 = 0;
    public void Move2()
    {
        if(!HasAwaytpoint)
        {

            HasAwaytpoint = true;
            i2 = Random.Range(0, Waypoints2.Length);
            w2 = Waypoints2[i2].transform.position;
        }


        Vector3 direction = p.player.transform.position - boss.transform.position;
        float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
        float angle = Mathf.SmoothDampAngle(boss.transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, 0);
        boss.transform.rotation = Quaternion.Euler(0f, angle, 0f);

        rb.position = Vector3.MoveTowards(rb.position, w2, 12 * Time.deltaTime);

        if(w2 == rb.position)
        {
            HasAwaytpoint = false;
            i2 = 0;
            w2 = Vector3.zero;
            Move2Over = true;
        }
    }

    private Vector3 GravPos;
    public GameObject GravitySkillPrefab;


    public void gravityAttack()
    {
        if (!animEnded)
        {
            animator.Play("Gravity");
            animator.SetBool("IsCasting", true);
            GravPos = p.player.transform.position;
        }
    }
    public void CastGravity()
    {
        Instantiate(GravitySkillPrefab, GravPos, Quaternion.identity);
    }

    public void GravEnd()
    {
        animEnded = true;
        animator.SetBool("IsCasting", false);
    }



    public GameObject SpinEffectPrefab;
    private GameObject SpinEffect;

    private Vector3 SpinDirection;

    public void SpinAttack()
    {
        if (!animEnded)
        {
            animator.Play("Spin");
            animator.SetBool("IsCasting", true);
           SpinDirection = p.player.transform.position - boss.transform.position;
        }

        rb.isKinematic = false;

        
      

        rb.AddForce(SpinDirection * 20);
   
     if(SpinEffect != null)
        {
            SpinEffect.transform.position = boss.transform.position;
        }
    }

    public void SpinEffectCast()
    {
        SpinEffect = Instantiate(SpinEffectPrefab, boss.transform.position, Quaternion.identity);
      
    }

    public void SpinOver()
    {
        Destroy(SpinEffect);
        animEnded = true;
        animator.SetBool("IsCasting", false);
        rb.isKinematic = true;
    }


    public GameObject IceWheelsPrefab;
    public GameObject PortalPrefab;


    public GameObject IceWheelCastSpot;

    public void IceWheelSkill()
    {
        if (!animEnded)
        {
            animator.Play("IceWheels");
            animator.SetBool("IsCasting", true);
        }

        Vector3 direction = p.player.transform.position - boss.transform.position;
        float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
        float angle = Mathf.SmoothDampAngle(boss.transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, 0);
        boss.transform.rotation = Quaternion.Euler(0f, angle, 0f);
    }

    public void IceWheelCast()
    {

       Instantiate(IceWheelsPrefab, IceWheelCastSpot.transform.position, Quaternion.identity);
    }

    public void EndIceWheel()
    {
       
        animator.SetBool("IsCasting", false);
        animEnded = true;
    }





    public GameObject BlackHoleCamera;
    public GameObject SpaceCamera;
    public GameObject WarpCamera;
    public GameObject WarpEffect;


    private bool finalFaseStart = false;

    private float countdown = 0;
    private bool hasSummonedWarp = false;
    public void Update()
    {
        if(behaviorTree.boss == 1)
        {
            if (bossStat.health < 1000)
            {
                if (bossStat.health < 500 )
                {
                    stage = 3;
                    behaviorTree.enabled = false;
                    BlackHole();
                    if(blackHolecode != null)
                    {
                        swordColl.enabled = false;

                        if (blackHolecode.countdown < 2f)
                        {
                            BlackHoleCamera.SetActive(true);
                           
                        }
                        else if(blackHolecode.countdown2 < 3)
                        {
                            WarpCamera.SetActive(true);
                            BlackHoleCamera.SetActive(false);
                            if (!hasSummonedWarp)
                            {
                                hasSummonedWarp = true;
                                Instantiate(WarpEffect, WarpCamera.transform.position + (WarpCamera.transform.forward * 13), Quaternion.identity);
                            }
                      
                        }
                        else if (blackHolecode.countdown2 < 6)
                        {
                          
                            SpaceCamera.SetActive(true);
                            BlackHoleCamera.SetActive(false);
                            WarpCamera.SetActive(false);
                        }
                        else
                        {
                            BlackHoleCamera.SetActive(false);
                            SpaceCamera.SetActive(false);
                            WarpCamera.SetActive(false);
                        
                        }
                    }
               
                  

                }
                else
                {
                    stage = 2;
                }

            }
        }
        
   
       
    }

}
