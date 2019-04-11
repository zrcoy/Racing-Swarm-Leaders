using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackManager : MonoBehaviour {
    public Catmul[] splines;
    public GameObject splinePrefab;
    public GameObject[] swarmleaderPrefab;
    public string[][] maskNames;

	// Use this for initialization
	void Start () {

        maskNames = new string[5][];

        maskNames[0] = new string[] { "flock1", "flock2", "flock3", "flock4" };
        maskNames[1] = new string[] { "flock0", "flock2", "flock3", "flock4" };
        maskNames[2] = new string[] { "flock0", "flock1", "flock3", "flock4" };
        maskNames[3] = new string[] { "flock0", "flock1", "flock2", "flock4" };
        maskNames[4] = new string[] { "flock0", "flock1", "flock2", "flock3" };
        splines = new Catmul[5]; // TODO - change
        splines[0] = Instantiate(splinePrefab, new Vector3(0, 0, 0), Quaternion.identity).GetComponent<Catmul>(); // middle track
        // TODO add code here
        splines[1] = Instantiate(splinePrefab, new Vector3(-30, 0, 30), Quaternion.identity).GetComponent<Catmul>(); // top left track
        splines[2] = Instantiate(splinePrefab, new Vector3(30, 0, 30), Quaternion.identity).GetComponent<Catmul>(); // top right track
        splines[3] = Instantiate(splinePrefab, new Vector3(-30, 0, -30), Quaternion.identity).GetComponent<Catmul>(); // bottom left track
        splines[4] = Instantiate(splinePrefab, new Vector3(30, 0, -30), Quaternion.identity).GetComponent<Catmul>(); // bottom right track
        for (int i = 0; i < 5; i++) // TO DO - change code
        {
            splines[i].GenerateSpline();
        }
        // spawn the flocks on the tracks.  Track 0 is where the player begins.
        for (int i = 0; i < 5; i++) // TO DO CHANGE CODE 
        {
            // TO DO - Spawn the swarm leader
            GameObject swarmLeader = Instantiate(swarmleaderPrefab[i], splines[i].sp[i].transform.position, Quaternion.identity);
            Flock flock = swarmLeader.GetComponent<Flock>();
            Vector3 pos = flock.boidPrefab.transform.position;
            pos.y = 0.05f;
            flock.boidPrefab.transform.position = pos;
            // TODO - Get the follow track script, and tell it about the track manager (so it can find more tracks), and the spline.
            // make sure to set the mask on the flock, and to say which is the player. 
            flock.mask = maskNames[i];
            //flock.target = swarmLeader;
            swarmLeader.GetComponent<BehaviorTree>().SetValue("TrackManager",this);
            swarmLeader.GetComponent<BehaviorTree>().SetValue("TrackIndex", i);

            swarmLeader.GetComponent<BehaviorTree>().SetValue("Waypoint", splines[i].sp[i]);
            swarmLeader.GetComponent<BehaviorTree>().SetValue("Waypoints", splines[i].sp);
            swarmLeader.GetComponent<BehaviorTree>().SetValue("Index", i);
            swarmLeader.GetComponent<BehaviorTree>().SetValue("TurnRequested", Turning.STRAIGHT);
            if (i ==0)
            {
                flock.player = true;
            }
            else
            {
                flock.player = false;
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
