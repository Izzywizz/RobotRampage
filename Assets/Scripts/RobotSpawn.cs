using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotSpawn : MonoBehaviour {

    [SerializeField]
    GameObject[] robots; //an array of robots game objects that will be instantiated (yellow/ blue/ red)

    private int timesSpawned; //keep track of the spawn cycle of robots
    private int healthBonus = 0; //each new robot spawn wave will get a bit of extra health, making the game harder

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SpawnRobot()
    {
        //Spawn a robot, set its health and position
        timesSpawned++;
        healthBonus += 1 * timesSpawned;
        GameObject robot = Instantiate(robots[Random.Range(0, robots.Length)]);
        robot.transform.position = transform.position;
        robot.GetComponent<Robot>().health += healthBonus;
    }
}
