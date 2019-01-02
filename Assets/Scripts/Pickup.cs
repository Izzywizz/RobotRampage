using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour {

    public int type; //represents the type of pickup

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //this method listens for a collisions with the Player gameObject, calls pickupItme method from the Player and passes in the type
    // of the pickup item which is represented as an int, it then destroys itself
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Player>() != null && other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<Player>().PickUPItem(type);
            GetComponentInParent<PickupSpawn>().PickupWasPickedUp(); //now when the pickup collides with the player, it will signal PickupSpawn script to start the spawn timer
            Destroy(gameObject);
        }
    }
}
