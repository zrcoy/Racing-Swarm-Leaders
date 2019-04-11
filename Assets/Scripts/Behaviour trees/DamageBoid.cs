using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageBoid : Task {
    GameObject hitTarget;
    // Use this for initialization
    public override NodeResult Execute()
    {
        hitTarget = (GameObject)tree.GetValue("HitObject");
        hitTarget.GetComponent<Boid>().speed *= 1.1f;
        hitTarget.GetComponent<Boid>().turnspeed *= .9f;

        return NodeResult.SUCCESS;
    }

    public override void Reset()
    {
        hitTarget = (GameObject)tree.GetValue("HitObject");
        base.Reset();
    }
}
