using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZapTarget : Task {
    LineRenderer line;
    GameObject hitTarget;
    GameObject selfBoid;
    // Use this for initialization
    public override NodeResult Execute() { 
        hitTarget = (GameObject)tree.GetValue("HitObject");
        selfBoid = (GameObject)tree.GetValue("selfBoid");
        line.positionCount = 2;
        line.SetPosition(0, selfBoid.transform.position);
        line.SetPosition(1, hitTarget.transform.position);
        return NodeResult.SUCCESS;
    }

    public override void Reset()
    {
        hitTarget = (GameObject)tree.GetValue("HitObject");
        selfBoid = (GameObject)tree.GetValue("selfBoid");
        line = (LineRenderer)tree.GetValue("Line");
        base.Reset();
    }

}
