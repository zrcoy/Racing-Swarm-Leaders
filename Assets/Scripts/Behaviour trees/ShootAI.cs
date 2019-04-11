using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootAI : BehaviorTree
{
    public GameObject Boid;
    public LineRenderer line;
	// Use this for initialization
	void Start ()
    {
        Selector TreeRoot = new Selector();
        Sequence ShootSequence = new Sequence();
        DetectTarget detectTask = new DetectTarget();
        ZapTarget zapTask = new ZapTarget();
        DamageBoid damageBoidTask = new DamageBoid();

        SetValue("selfBoid", Boid);
        SetValue("Line", line);

        ShootSequence.children.Add(detectTask);
        ShootSequence.children.Add(zapTask);
        ShootSequence.children.Add(damageBoidTask);
        TreeRoot.children.Add(ShootSequence);
        ShootSequence.tree = this;
        TreeRoot.tree = this;
        detectTask.tree = this;
        zapTask.tree = this;
        damageBoidTask.tree = this;
        root = TreeRoot;
    }
}
