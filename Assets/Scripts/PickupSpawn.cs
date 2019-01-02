using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupSpawn : MonoBehaviour {

    [SerializeField]
    private GameObject[] pickups; //Will store all possible pickup types in array

	// Use this for initialization
	void Start () {
        spawnPickup(); //spawn a pickup as soon as the game begins
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void PickupWasPickedUp()
    {
        StartCoroutine("respawnPickup"); //when the pickup has been pickedup by the player, start the respawning process
    }

    //1 - Instantiates a random pickup and sets its position to that of the PickupSpawn GameObject
    public void spawnPickup()
    {
        //Instantiate a random pickup
        GameObject pickup = Instantiate(pickups[Random.Range(0, pickups.Length)]);
        pickup.transform.position = transform.position;
        pickup.transform.parent = transform;
    }

    //2 Wait 20 seconds before calling spawnPickup
    IEnumerator respawnPickup()
    {
        yield return new WaitForSeconds(20);
        spawnPickup();
    }
}
