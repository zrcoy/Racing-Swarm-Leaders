using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour {

	// Use this for initialization
    public GameObject player;
    public BehaviorTree playerBT;

    void Start () {

       playerBT = player.GetComponent<BehaviorTree>();
    


    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.W))
            playerBT.SetValue("TurnRequested", Turning.STRAIGHT);
        if (Input.GetKeyDown(KeyCode.A))
            playerBT.SetValue("TurnRequested", Turning.LEFT);
        if (Input.GetKeyDown(KeyCode.D))
            playerBT.SetValue("TurnRequested", Turning.RIGHT);
    }
}
