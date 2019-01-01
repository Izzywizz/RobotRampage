using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot : MonoBehaviour {

    [SerializeField]//exposing the attribute to the Inspector again with Serialize but not other scripts
    private string robotType; //red/blue or yellow robot, this variable name matches a Constant name we've give earlier

    private Transform player; //track the player
    private float timeLastFired;

    private bool isDead;

    public int health;
    public int range;
    public float fireRate;

    public Animator robot;

    public Transform missleFireSpot;
    UnityEngine.AI.NavMeshAgent agent; //NavMesh for the robot

    [SerializeField]
    GameObject misslePrefab; //the prefab for the missle

	// Use this for initialization
	void Start () {

        //1 - All robots are alive, you obtain the agent values for the respective robot and player values
        isDead = false;
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {
        //2 - check for dead robots, no zombie robts allowed.
        if (isDead)
        {
            return;
        }
        //3 - Turn the robot to face the player
        transform.LookAt(player);

        //4 - use the navMesh to find the player and move towards the player re all that player.position is vectpr34
        agent.SetDestination(player.position);

        //5 - check to see if the robot is within firing range and hasn't fired recently
        if (Vector3.Distance(transform.position, player.position) < range
            && Time.time - timeLastFired > fireRate)
        {
            //6 -update timeLastFired to current time then use fire() method
            timeLastFired = Time.time;
            fire();
        }
    }

    private void fire()
    {
        //Create a misslePrefab then sets its position and rotation to that of the robots firing spot/
        GameObject missle = Instantiate(misslePrefab);
        missle.transform.position = missleFireSpot.transform.position;
        missle.transform.rotation = missleFireSpot.transform.rotation;
        robot.Play("Fire"); //animation for the robot to fire
    }
}
