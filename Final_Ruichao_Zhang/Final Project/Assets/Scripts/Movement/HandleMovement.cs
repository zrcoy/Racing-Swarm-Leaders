using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleMovement : BehaviorTree {
    // Use this for initialization
    public float Speed;
    public float TurnSpeed;
    public float Accuracy;
    public TrackManager trackManager;

    void Start ()
    {
        Selector TreeRoot = new Selector();
        Sequence Patrol = new Sequence();
        MoveTo MoveToWP = new MoveTo();
        PlayerChangeLane playerChangeLane = new PlayerChangeLane();
        SelectNextGameObject PickNextWP = new SelectNextGameObject();


        //TurnSpeed = 2.0f;
        //Speed = 5.0f;
        //Accuracy = 1.5f;
        SetValue("TurnSpeed", TurnSpeed);
        SetValue("Speed", Speed);
        SetValue("Accuracy", Accuracy);
        SetValue("Direction",1);

        MoveToWP.TargetName = "Waypoint";
        PickNextWP.ArrayKey = "Waypoints";
        PickNextWP.GameObjectKey = "Waypoint";
        PickNextWP.IndexKey = "Index";
        PickNextWP.DirectionKey = "Direction";

        Patrol.children.Add(MoveToWP);
        Patrol.children.Add(PickNextWP);
        Patrol.children.Add(playerChangeLane);
        TreeRoot.children.Add(Patrol);
        Patrol.tree = this;
        TreeRoot.tree = this;
        MoveToWP.tree = this;
        playerChangeLane.tree = this;
        PickNextWP.tree = this;
        root = TreeRoot;
    }


    public override void Update()
    {
        SetValue("Speed", Speed);
        SetValue("TurnSpeed", TurnSpeed);
        SetValue("Accuracy", Accuracy);

        base.Update();
    }

}
