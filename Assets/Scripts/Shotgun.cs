using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : Gun
{
    protected override void Update()
    {
        base.Update(); //calls parent functionality
        // Shotgun & Pistol have semi-auto fire rate
        if (Input.GetMouseButtonDown(0) && (Time.time - lastFireTime) > fireRate)//checks whether enough time has elapsed between shots to allow for another
        { //if it has, then trigger fire animation
            lastFireTime = Time.time;
            base.Fire();

        }
    }

}