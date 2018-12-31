using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {

    public float fireRate; //rate of fire
    protected float lastFireTime; //time since last blast
    public Ammo ammo; //used for tracking gun ammunition
    public AudioClip liveFire;
    public AudioClip dryFire;


	// Use this for initialization
	void Start () {
        lastFireTime = Time.time - 10; // user is able to fire immediately
	}

    protected virtual void Update() //able to subclass/override in subclass classes
    {

    }

    protected void Fire() // Remember each weapon fire will have its own slight variable on these methods
    {
        //Checks if the player has bullet, fire away with the sound, if not play the empty clip. It should consume ammo when fired
        if (ammo.HasAmmo(tag))
        {
            GetComponent<AudioSource>().PlayOneShot(liveFire);
            ammo.ConsumeAmmo(tag);
        }
        else
        {
            GetComponent<AudioSource>().PlayOneShot(dryFire);
        }
        //grabs the animator controller for weapon in use and plays its animatior
        GetComponentInChildren<Animator>().Play("Fire");
    }
}
