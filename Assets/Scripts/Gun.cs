using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {

    public float fireRate; //rate of fire
    protected float lastFireTime; //time since last blast
    public Ammo ammo; //used for tracking gun ammunition
    public AudioClip liveFire;
    public AudioClip dryFire;
    public float zoomFactor; //level of zoom when RMB is pressed
    public int range; //how far the gun can hit the target
    public int damage; 

    private float zoomFOV; //field of view based on the zoom factor
    private float zoomSpeed = 6;


	// Use this for initialization
	void Start () {
        lastFireTime = Time.time - 10; // user is able to fire immediately
        zoomFOV = Constants.CameraDefaultZoom / zoomFactor; //init zoom factor
        lastFireTime = Time.time - 10;
	}

    protected virtual void Update() //able to subclass/override in subclass classes
    {
        // Right click (zoom)
        if (Input.GetMouseButton(1))
        { //when presssed, the camera smoothly transitions/ animates the zoom effect via lerp
            Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, zoomFOV, zoomSpeed * Time.deltaTime);
        }
        else
        {
            Camera.main.fieldOfView = Constants.CameraDefaultZoom;
        }
    }

    protected void Fire() // Remember each weapon fire will have its own slight variable on these methods
    {
        //Checks if the player has bullet, fire away with the sound, if not play the empty clip. It should consume ammo when fired
        if (ammo.HasAmmo(tag))
        {
            GetComponent<AudioSource>().PlayOneShot(liveFire);
            ammo.ConsumeAmmo(tag);

            //grabs the animator controller for weapon in use and plays its animatior
            GetComponentInChildren<Animator>().Play("Fire");

            //raycasting from the camera to a point (Viewport coordinates are normalized and relative to the camera)
            Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
            RaycastHit hit; //if you get a hit, it will be populated with an obj
            if (Physics.Raycast(ray, out hit, range)) //this actully casts the ray
            {
                processHit(hit.collider.gameObject); //what gameObj that was hit by the ray is passed on to the method to handle the hit
            }
        }
        else
        {
            GetComponentInChildren<Animator>().Play("Fire");
            GetComponent<AudioSource>().PlayOneShot(dryFire);
        }

    }

    //raycasting must be used to determine whether the robot was hit (raycasting is when you fire an invisable ray to check for collisiions)
    private void processHit(GameObject hitObject)
    {
        //This determine which gameObject (Player or Robot) has been hit and passes teh damage on.
        // recall that if the object is not null then its the one being hit

        if (hitObject.GetComponent<Player>() != null) 
        {
            Debug.Log("Player Damage Done: " + damage);
            hitObject.GetComponent<Player>().TakeDamage(damage);
        }

        if (hitObject.GetComponent<Robot>() != null)
        {
            Debug.Log("Robot Damage Done: " + damage);
            hitObject.GetComponent<Robot>().TakeDamage(damage);
        }
    }
}
