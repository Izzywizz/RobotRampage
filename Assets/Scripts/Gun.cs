using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {

    public float fireRate; //rate of fire
    protected float lastFireTime; //time since last blast

	// Use this for initialization
	void Start () {
        lastFireTime = Time.time - 10; // user is able to fire immediately
	}

    protected virtual void Update() //able to subclass/override in subclass classes
    {

    }

    protected void Fire() // Remeeber each weapon fire will have its own slight variable on these methods
    {

    }
}
