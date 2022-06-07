using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Suck : MonoBehaviour
{
    public bool gotSucked = false;
    private GameObject player;
    private CharacterController characterController;
    private GameObject BlockCamera;

    private Renderer rend;

    private GameObject FinalWaypoint;
    public float countdown = 0;
    public float countdown2 = 0;
    public float Aplha = 1;

    private GameObject Boss;
    public BehaviorTreeAgent bt;
    private Color color;

    private GameObject Camera;


    private bool ISteleported =  false;
    void Start()
    {
        
    


      
        Boss = GameObject.FindGameObjectWithTag("Boss2");
        bt = Boss.GetComponent<BehaviorTreeAgent>();
        player = GameObject.FindGameObjectWithTag("Player");
        characterController = player.GetComponent<CharacterController>();

        BlockCamera = GameObject.FindGameObjectWithTag("BlockCamera");
        rend = BlockCamera.GetComponent<Renderer>();

        FinalWaypoint = GameObject.FindGameObjectWithTag("WaypointFinal");

        color = rend.material.color;
        color.a = 0;
        rend.material.color = color;
        
    }

        void Update()
    {
        float dist = Vector3.Distance(player.transform.position, transform.position);


        

        if (dist > 13 && gotSucked == false)
        {
            Vector3 pulldirection = (transform.position - player.transform.position).normalized;
            characterController.SimpleMove(pulldirection * 20);
        }
        else
        {

            gotSucked = true;


            color.a = Aplha;

            rend.material.color = color;

            countdown += Time.deltaTime;


            if(!ISteleported)
            {
                player.transform.position = FinalWaypoint.transform.position;
                ISteleported = true;
            }
        

            if (countdown > 5)
            {
              

                if(Aplha > 0)
                {
                    Aplha -= Time.deltaTime/40;
                }
               
                    countdown2 += Time.deltaTime;
                
                    if(countdown2 > 6)
                    {
                        bt.enabled = true;
                        
                    }
                 
               

                

                
             
                color.a = Aplha;

            }
        }








    }



}
