using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssaultRifle : Gun
{
    protected override void Update()
    {
        base.Update();
        //Automatic fire
        if (Input.GetMouseButton(0) && Time.time - lastFireTime > fireRate) //held down instead of pressed once, to activate auto fire
        {
            lastFireTime = Time.time;
            Fire();
        }
    }
}