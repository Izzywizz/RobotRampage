using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunEquipper : MonoBehaviour {

    public static string activeWeaponType;

    public GameObject pistol;
    public GameObject assaultRifle;
    public GameObject shotgun;
    [SerializeField]
    public GameUI gameUI;

    GameObject activeGun;

    [SerializeField]
    private Ammo ammo;

	void Start () {
        // Starting gun is initilized to be the pistol
        activeWeaponType = Constants.Pistol;
        activeGun = pistol;
	}
	
	// Update is called once per frame
	void Update () {

        //Checking the input for each frame lke this is known as Polling
        if (Input.GetKeyDown("1"))
        {
            loadWeapon(pistol);
            activeWeaponType = Constants.Pistol;
            gameUI.UpdateReicle();
        } 
        else if (Input.GetKeyDown("2"))
        {
            loadWeapon(assaultRifle);
            activeWeaponType = Constants.AssaultRifle;
            gameUI.UpdateReicle();
        }
        else if (Input.GetKeyDown("3"))
        {
            loadWeapon(shotgun);
            activeWeaponType = Constants.Shotgun;
            gameUI.UpdateReicle();
        }

    }

    /// <summary>
    /// Gets the active weapon. Recall the activeGun is private thus no one can modify but this method helps see what it is.
    /// </summary>
    /// <returns>The active weapon.</returns>
    public GameObject GetActiveWeapon()
    {
        return activeGun;
    }

    ///Change and load weapon
    private void loadWeapon(GameObject weapon)
    {
        pistol.SetActive(false);
        assaultRifle.SetActive(false);
        shotgun.SetActive(false);

        weapon.SetActive(true);
        activeGun = weapon;
        gameUI.SetAmmoText(ammo.GetAmmo(activeGun.tag));
    }
}
