using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public Transform cam;
    public StaffCollision staff;

    //movement stuff
    private float jumpHeight;
    private Vector3 velocity;
    private float gravity;
    private float speed;
    private float y;
    private float turnSmoothTime;
    private float turnSmoothVelocity;
    private bool jumpStart = false;
    private bool grounded;
    private bool jump = false;
    private bool air;

    //block stuff
    private bool block;
    public bool blockframes;
    private float blockcooldown;

    //dodge stuff
    private bool dodge;
    public AnimationCurve dodgecurve;
    private bool onGround;
    public bool dodgeframes;
    private float dodgecooldown;

    //attack stuff
    public bool attackframes;
    private bool attack;
    private int attacklightcount;
    private int attackfinishcount;
    private float attackcooldown;
    private bool attackchain;
    public List<Enemy> enemylist;
    public GameObject target;
    public Vector3 targetdirection;
    private bool magicAttack;

    private bool overhead;
    private bool thrust;

    private Vector3 lastdirection;
    public GameObject boulder;
    private float searchDist;

    public float mana;
    public bool manaRecharge;
    public float health;
    public bool heal;

    //Animations
    public Animator animator;

    private void Awake()
    {
        enemylist = new List<Enemy>();
    }

    void Start()
    {
        health = 250;
        mana = 100;
        jumpHeight = 30f;
        gravity = -30f;
        speed = 500f;
        turnSmoothTime = 0.01f;

        block = false;
        blockframes = false;

        lastdirection = new Vector3(1f, 0f, 0f);

        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = false;
        Cursor.visible = false;
    }

    void Update()
    {
        AttackUpdate();
        DodgeUpdate();
        Block();
        JumpUpdate();
        Animations();
        Heal();

        animator.SetBool("isGrounded", controller.isGrounded);
        animator.SetFloat("VelocityY", velocity.y);


        if (health <= 0)
        {
            Destroy(gameObject);
        }

        if(mana <= 0 && !manaRecharge)
        {
            mana = 0;
            manaRecharge = true;
        }
        else if(mana < 100 && manaRecharge)
        {
            mana += Time.deltaTime * 5;
        }
        else if(manaRecharge)
        {
            manaRecharge = false;
            mana = 100;
        }
    }
    private void FixedUpdate()
    {
        AttackFixedUpdate();
        DodgeFixedUpdate();
        if (!block && !dodge && !attack && !heal)
        {
            MoveDirectionFixed();
            JumpFixed();
        }
        controller.Move(velocity * Time.fixedDeltaTime);
    }


    private void JumpUpdate()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            if (Input.GetKeyDown(KeyCode.Space) && controller.isGrounded && jump == false && jumpStart == false)
            {
                animator.Play("JumpStart", 0, 0);
                jump = true;
                jumpStart = true;
            }

        }
        else
        {
            if(jumpStart == false)
            jump = false;
        }
    }

    private void MoveDirectionFixed()
    {
        Vector3 direction = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;

            velocity = new Vector3(moveDirection.x * speed * Time.fixedDeltaTime, velocity.y, moveDirection.z * speed * Time.fixedDeltaTime);
        }
        else
            velocity = new Vector3(0f, velocity.y, 0f);
    }

    private void JumpFixed()
    {
        if (controller.isGrounded && jump == false)
        {
            velocity = new Vector3(velocity.x, -10f, velocity.z);
        }
        else
        {
            if (velocity.y > gravity)
            {
                velocity = new Vector3(velocity.x, velocity.y + gravity * Time.fixedDeltaTime, velocity.z);
            }

            if (jump == false && velocity.y >= 5f)
            {
                velocity = new Vector3(velocity.x, 5f, velocity.z);
            }
        }
    }

    private void JumpAnim()
    {
        velocity = new Vector3(velocity.x, jumpHeight, velocity.z);
    }

    private void JumpEnd()
    {
        jumpStart = false;
    }


    private void Block()
    {
        if (Input.GetMouseButtonDown(1) && !block && !dodge && blockcooldown <= 0f && !HoldMoveKeys())
        {
            block = true;
            velocity = Vector3.zero;
            animator.SetBool("isBlocking", true);
            animator.Play("Block", 0, 0);

            AttackFramesEnd();
            AttackReset();

            DodgeFramesEnd();
            DodgeReset();
        }

        if(blockcooldown > 0f && !block)
        {
            blockcooldown -= Time.deltaTime;
        }
    }

    private void BlockFramesStart()
    {
        blockframes = true;
    }

    private void BlockFramesEnd()
    {
        blockframes = false;
    }

    private void BlockReset()
    {
        block = false;
        blockcooldown = 0.3f;
        animator.SetBool("isBlocking", false);
    }

    private void Heal()
    {
        if(Input.GetKeyDown(KeyCode.V) && !dodge && !block && !heal && !manaRecharge)
        {
            heal = true;
            mana = 0;
            AttackFramesEnd();
            AttackReset();

            BlockFramesEnd();
            BlockReset();

            DodgeFramesEnd();
            DodgeReset();

            animator.SetBool("isHealing", true);
            animator.Play("Heal", 0, 0);

        }
    }

    private void HealAnim()
    {
        health = 250;
    }

    private void HealEnd()
    {
        heal = false;
        animator.SetBool("isHealing", false);
    }

    private void DodgeUpdate()
    {
        if (Input.GetMouseButtonDown(1) && !dodge && !block && dodgecooldown <= 0 && HoldMoveKeys())
        {
            dodge = true;
            velocity = Vector3.zero;
            animator.SetBool("isDodging", true);
            onGround = controller.isGrounded;
            float targetAngle = Mathf.Atan2(lastdirection.x, lastdirection.z) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, targetAngle, 0f);

            if (onGround)
                animator.Play("Dodge", 0, 0);
            else
                animator.Play("AirDash", 0, 0);

            AttackFramesEnd();
            AttackReset();

            BlockFramesEnd();
            BlockReset();

            JumpEnd();

        }

        if(!dodge && dodgecooldown > 0f)
        {
            dodgecooldown -= Time.deltaTime;
        }
    }

    private void DodgeFixedUpdate()
    {
        if (dodge)
        {
            if(onGround)
            velocity = new Vector3(lastdirection.x * 20, -10f, lastdirection.z * 20);
            else
            {
                velocity = new Vector3(lastdirection.x, 0f, lastdirection.z) * dodgecurve.Evaluate(animator.GetCurrentAnimatorStateInfo(0).normalizedTime / animator.GetCurrentAnimatorStateInfo(0).length);
            }
        }
    }

    private void DodgeFramesStart()
    {
        dodgeframes = true;
    }

    private void DodgeFramesEnd()
    {
        dodgeframes = false;
    }

    private void DodgeReset()
    {
        dodge = false;
        dodgecooldown = 0.3f;
        velocity = Vector3.zero;
        animator.SetBool("isDodging", false);
    }

    private void AttackUpdate()
    {
        if (HoldMoveKeys())
        {
            lastdirection = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
            float targetAngle = Mathf.Atan2(lastdirection.x, lastdirection.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            lastdirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
        }

        if ((Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.C)) && !block && !dodge && attackcooldown <= 0f)
        {
            if (!attack)
            {
                target = null;
                velocity = Vector3.zero;
                targetdirection = Vector3.zero;
                attack = true;
                attackchain = false;
                attacklightcount = 1;
                attackfinishcount = 1;

                if (CheckCloseEnemy())
                {
                    for (int i = 0; i < enemylist.Count; i++)
                    {
                        if (Vector3.Distance(transform.position, enemylist[i].transform.position) <= 40)
                        {
                            if (targetdirection == Vector3.zero)
                            {
                                target = enemylist[i].gameObject;
                            }
                            else
                            {
                                if (Vector3.Distance(transform.position, enemylist[i].transform.position) < Vector3.Distance(transform.position, target.transform.position))
                                {
                                    target = enemylist[i].gameObject;
                                }
                            }
                        }
                    }
                    targetdirection = new Vector3(target.transform.position.x - transform.position.x, 0f, target.transform.position.z - transform.position.z).normalized;
                    float targetAngle = Mathf.Atan2(targetdirection.x, targetdirection.z) * Mathf.Rad2Deg;
                    transform.rotation = Quaternion.Euler(0f, targetAngle, 0f);

                }
                else
                {
                    targetdirection = transform.forward;
                }

                Attack();
            }
            else if (attackchain && attackfinishcount <= 1)
            {

                if (target)
                {
                    targetdirection = new Vector3(target.transform.position.x - transform.position.x, 0f, target.transform.position.z - transform.position.z).normalized;
                }
                else
                {
                    targetdirection = transform.forward;
                }
                attackchain = false;
                float targetAngle = Mathf.Atan2(targetdirection.x, targetdirection.z) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.Euler(0f, targetAngle, 0f);

                if (attacklightcount <= 2)
                {
                    attacklightcount++;
                }
                else if(attackfinishcount <= 1)
                {
                    attackfinishcount++;
                }

                Attack();
            }
        }

        if(attackcooldown > 0f && !attack)
        {
            attackcooldown -= Time.deltaTime;
        }
    }

    private void AttackFixedUpdate()
    {
        if (!attackchain && attack && !attackframes && !magicAttack)
        {
            if (target)
            {
                if (Vector3.Distance(target.transform.position, transform.position) > 2f)

                    transform.position = Vector3.MoveTowards(transform.position, target.transform.position - targetdirection * 2, 30 * Time.fixedDeltaTime);
            }
            else
            {
                velocity = new Vector3(targetdirection.x * 400f, 0f, targetdirection.z * 400f) * Time.fixedDeltaTime;
            }
        }
    }

    private void Attack()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if(attacklightcount <= 2)
            {
                if (target && (Vector3.Distance(transform.position, target.transform.position) < 10 && Vector3.Distance(transform.position, target.transform.position) > 2))
                {
                    animator.SetBool("isAttacking", true);
                    animator.Play("AttackGapCloser", 0, 0);
                    magicAttack = false;
                }
                else if(!overhead)
                {
                    animator.SetBool("isAttacking", true);
                    animator.Play("AttackOverhead", 0, 0);
                    magicAttack = false;
                    overhead = true;
                }
                else if(!thrust)
                {
                    animator.SetBool("isAttacking", true);
                    animator.Play("AttackThrust", 0, 0);
                    magicAttack = false;
                    thrust = true;
                }
            }
            else if(attacklightcount == 3 && attackfinishcount <= 1)
            {
                animator.SetBool("isAttacking", true);
                animator.Play("AttackFinisher1", 0, 0);
                magicAttack = false;
            }
        }
        else if (Input.GetKeyDown(KeyCode.C) && !manaRecharge)
        {
            mana -= 20;
            animator.SetBool("isAttacking", true);
            animator.Play("Magic", 0, 0);
            magicAttack = true;
        }
        else
        {
            AttackReset();
        }
    }

    private void AttackFramesStart()
    {
        attackframes = true;
        velocity = Vector3.zero;
    }

    private void AttackFramesEnd()
    {
        attackframes = false;
        attackchain = true;
        for (int i = 0; i < enemylist.Count; i++)
        {
            enemylist[i].framehit = false;
        }
    }

    private void AttackReset()
    {
        attack = false;
        attacklightcount = 0;
        attackfinishcount = 0;
        attackcooldown = 0.3f;
        animator.SetBool("isAttacking", false);
        overhead = false;
        thrust = false;
    }

    private void CastBoulder()
    {
        attackchain = true;
        GameObject boulderPREFAB = Instantiate(boulder, new Vector3(staff.transform.position.x, staff.transform.position.y, staff.transform.position.z), Quaternion.identity);
        boulderPREFAB.GetComponent<Boulder>().player = this;
    }


    private bool HoldMoveKeys()
    {
        if (Input.GetAxisRaw("Horizontal") != 0f || Input.GetAxisRaw("Vertical") != 0f)
            return true;
        else
            return false;
    }

    private bool CheckCloseEnemy()
    {
        for (int i = 0; i < enemylist.Count; i++)
        {
            if (Vector3.Distance(transform.position, enemylist[i].transform.position) <= searchDist)
            {
                return true;
            }
        }
        return false;
    }

    private void Animations()
    {
        if(HoldMoveKeys() && controller.isGrounded)
        {
            animator.SetBool("isWalking", true);
        }
        else
        {
            animator.SetBool("isWalking", false);
        }
    }


}
