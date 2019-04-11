using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DumbAI : BehaviorTree
{
    public GameObject dumbAI;
    // Use this for initialization
    void Start()
    {
        Selector TreeRoot = new Selector();
        Sequence WaitSequence = new Sequence();
        Wait Pause = new Wait();
        //PlayerChangeLane playerChangeLane = new PlayerChangeLane();
        AIPickDir AIDir = new AIPickDir();

        SetValue("TimeToWait", 3.0f);
        SetValue("DumbAI", dumbAI);
        Pause.TimeToWaitKey = "TimeToWait";




        WaitSequence.children.Add(Pause);
        WaitSequence.children.Add(AIDir);
        TreeRoot.children.Add(WaitSequence);
        WaitSequence.tree = this;
        TreeRoot.tree = this;
        Pause.tree = this;
        AIDir.tree = this;
        root = TreeRoot;
    }
    public override void Update()
    {
 

        base.Update();
    }

}
