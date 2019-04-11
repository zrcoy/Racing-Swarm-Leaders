using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIPickDir : Task {
    public int laneIndex;
    public GameObject dumbAI;
    public override NodeResult Execute()
    {
        laneIndex = Random.Range(0, 2);
        switch(laneIndex)
        {
            case (0):
                
                dumbAI.GetComponent<BehaviorTree>().SetValue("TurnRequested", Turning.STRAIGHT);
                break;
            case (1):
                //tree.SetValue("TurnRequested", Turning.LEFT);
                dumbAI.GetComponent<BehaviorTree>().SetValue("TurnRequested", Turning.LEFT);

                break;
            case (2):
                //tree.SetValue("TurnRequested", Turning.RIGHT);
                dumbAI.GetComponent<BehaviorTree>().SetValue("TurnRequested", Turning.RIGHT);

                break;
        }
        return NodeResult.SUCCESS;
    }

    public override void Reset()
    {
        dumbAI = (GameObject)tree.GetValue("DumbAI");
        base.Reset();
    }
}
