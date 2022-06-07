using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TaskStatus { None, Success, Failure, Running }
public abstract class Task
{
    public TaskStatus status;
    protected List<Task> children;

    public abstract TaskStatus Run(BehaviorTreeAgent agent, WorldManager worldManager);

    public Task()
    {
        children = new List<Task>();
        status = TaskStatus.None;
    }

    public void AddChild(Task task)
    {
        children.Add(task);
    }

    public List<Task> GetChildren()
    {
        return children;
    }
}
