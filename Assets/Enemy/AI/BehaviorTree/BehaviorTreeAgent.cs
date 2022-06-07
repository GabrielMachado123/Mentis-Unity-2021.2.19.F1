using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class BehaviorTreeAgent : MonoBehaviour
{
    public WorldManager worldManager;

    private Task behaviorTree;
    private Task bt2;

    public float boss;

    private void Start()
    {


     
        if(boss == 1)
        {
            Task sequence6 = new Sequence();
            sequence6.AddChild(new ConditionStage1());
            sequence6.AddChild(new EletricBarrier());
            sequence6.AddChild(new RepositionInBehaviour());

            Task sequence5 = new Sequence();
            sequence5.AddChild(new ConditionStage1());
            sequence5.AddChild(new Laser2());
            sequence5.AddChild(new RepositionInBehaviour());

            Task sequence4 = new Sequence();
            sequence4.AddChild(new ConditionStage1());
            sequence4.AddChild(new Attack13());
            sequence4.AddChild(new RepositionInBehaviour());


            Task sequence3 = new Sequence();
            sequence3.AddChild(new ConditionStage1());
            sequence3.AddChild(new Attack12());
            sequence3.AddChild(new RepositionInBehaviour());

            Task sequence2 = new Sequence();
            sequence2.AddChild(new ConditionStage1());
            sequence2.AddChild(new Attack11());
            sequence2.AddChild(new RepositionInBehaviour());

            Task randomSelector1 = new NonDeterministic();
            randomSelector1.AddChild(sequence2);
            randomSelector1.AddChild(sequence3);
            randomSelector1.AddChild(sequence4);
            randomSelector1.AddChild(sequence5);
            randomSelector1.AddChild(sequence6);


            Task sequence7 = new Sequence();
            sequence7.AddChild(new ConditionStage2());
            sequence7.AddChild(new Attack21());
            sequence7.AddChild(new RepositionInBehaviour());


            Task sequence8 = new Sequence();
            sequence8.AddChild(new ConditionStage2());
            sequence8.AddChild(new Attack22());
            sequence8.AddChild(new RepositionInBehaviour());



            Task sequence9 = new Sequence();
            sequence9.AddChild(new ConditionStage2());
            sequence9.AddChild(new Attack23());
            sequence9.AddChild(new RepositionInBehaviour());


            Task sequence10 = new Sequence();
            sequence10.AddChild(new ConditionStage2());
            sequence10.AddChild(new Attack24());
            sequence10.AddChild(new RepositionInBehaviour());

            Task randomSelector2 = new NonDeterministic();
            randomSelector2.AddChild(sequence7);
            randomSelector2.AddChild(sequence8);
            randomSelector2.AddChild(sequence9);
            randomSelector2.AddChild(sequence10);








            Task Stage2 = new Sequence();
            Stage2.AddChild(new ConditionStage2());
            Stage2.AddChild(new HasJumped());
            Stage2.AddChild(randomSelector2);


            Task Stage1 = new Sequence();
            Stage1.AddChild(new ConditionStage1());
            Stage1.AddChild(randomSelector1);


            Task SelectorStage = new Selector();
            SelectorStage.AddChild(Stage1);
            SelectorStage.AddChild(Stage2);




            Decorator Stage = new RepeatDecorator();
            Stage.AddChild(SelectorStage);

            Task sequence1 = new Sequence();
            sequence1.AddChild(new MoveAction());
            sequence1.AddChild(Stage);


            Decorator IsInRoom = new RepeatDecorator();
            IsInRoom.AddChild(sequence1);




            behaviorTree = IsInRoom;
            behaviorTree.status = TaskStatus.Running;
        }
        else
        {

         
            Task GravAtt = new Sequence();
            GravAtt.AddChild(new GravAttack());
            GravAtt.AddChild(new IceWheel());
            GravAtt.AddChild(new MoveStage2());


            Task SpinMode = new Sequence();
            SpinMode.AddChild(new SpinAttack());
            SpinMode.AddChild(new MoveStage2());

            Task IceWheels = new Sequence();
            IceWheels.AddChild( new MoveStage2());
            IceWheels.AddChild(new IceWheel());



            Task randomSelector2 = new NonDeterministic();
            randomSelector2.AddChild(IceWheels);
            randomSelector2.AddChild(SpinMode);
            randomSelector2.AddChild(GravAtt);
         
        

            Decorator startBoss = new RepeatDecorator();
            startBoss.AddChild(randomSelector2);

            behaviorTree = startBoss;
            behaviorTree.status = TaskStatus.Running;
        }

       

    }

    private void Update()
    {
        if((behaviorTree.status == TaskStatus.Running) || (behaviorTree.status == TaskStatus.None))
        {
            behaviorTree.Run(this, worldManager);
        }
    }


    public bool IsAtDestionation(NavMeshAgent agent)
    {
        if (!agent.pathPending)
        {
            if (agent.remainingDistance <= agent.stoppingDistance)
            {
                if (!agent.hasPath || agent.velocity.sqrMagnitude == 0)
                {
                    return true;
                }
            }
        }
        return false;
    }
}
