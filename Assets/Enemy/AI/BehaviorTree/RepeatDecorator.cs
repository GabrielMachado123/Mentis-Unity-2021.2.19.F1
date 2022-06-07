using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatDecorator : Decorator
{
    public override TaskStatus Run(BehaviorTreeAgent agent, WorldManager worldManager)
    {
     
    

        if (status == TaskStatus.None)
        {
            status = TaskStatus.Running;
        }
        
            TaskStatus childStatus = child.Run(agent, worldManager);


            if (childStatus == TaskStatus.Success)
            {
                ResetTasks(this.GetDecoratorChild());

            }
       
        status = TaskStatus.Running;




        return status;
    }


    public void ResetTasks(Task t)
    {
        t.status = TaskStatus.None;

        foreach (Task tchild in t.GetChildren())
        {
            ResetTasks(tchild);

        }
    }
}
