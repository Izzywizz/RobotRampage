using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missle : MonoBehaviour {

    public float speed = 30f; //how fast the missle is traveling
    public int damage = 10; // the damage done to the player

	// Use this for initialization
    /* In very simplistic terms, a coroutine is related to threads/ and running multiple things aat one
     *  A coroutine is a much pleasant way of handing threads, it runs code at a certain designated time. They run on the main thread but only at intevals
     *  Coroutines take methods that return IEnumerator. These deciede the duration of the coroutinbe
     */   
	void Start () {
        //1 - When the missle is instantiated, the coroutine deathTimer is also called
        StartCoroutine("deathTimer");
	}
	
	// Update is called once per frame
	void Update () {
        //2 - Move the missle forward based on the speed multiplier by the time between frames
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
	}

    //3 - The method returns WaitForSeconds for 10 seconds, once these 10 seconds have passed, the method resumes after this point.
    // Thus the missle self desctructs if it doesn't hit its target after 10 seconds.
    IEnumerator deathTimer()
    {
        yield return new WaitForSeconds(10);
        Destroy(gameObject);
    }
}
