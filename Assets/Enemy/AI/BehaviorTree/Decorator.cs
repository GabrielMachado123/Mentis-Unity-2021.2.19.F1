using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Decorator : Task
{
    protected Task child;

    public new void AddChild(Task task)
    {
        child = task;
    }


    public Task GetDecoratorChild()
    {
        return child;
    }

}
