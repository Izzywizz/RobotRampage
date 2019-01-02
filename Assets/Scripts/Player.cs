using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public int health; //the players health
    public int armor; //reduces players health damage by 50% though once it goes, normal damge amount occurs
    public GameUI gameUI; //ref to scripts
    private GunEquipper gunEquipper;
    private Ammo ammo; //reference to ammo class

    public Game game; //reference to game script
    public AudioClip playerDead; //audio played when player dies

	// Use this for initialization
	void Start () {
        //obtain component refs to the scripts
        ammo = GetComponent<Ammo>();
        gunEquipper = GetComponent<GunEquipper>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    /// <summary>
    /// Takes the incoming damage and reduces it amount based on how much armor the player has remaing.
    /// if the player has no armor, then you apply the total damage to the players health.
    /// if the health reaches zero, gameover 
    /// </summary>
    /// <param name="amount">Amount.</param>
    public void TakeDamage(int amount)
    {

        int healthDamage = amount;

        if (armor > 0)
        {
            int effectiveArmor = armor * 2;
            effectiveArmor -= healthDamage;

            //If there is still armor, don't need to process health damage.
            if (effectiveArmor > 0)
            {
                armor = effectiveArmor / 2; //50% of it goes after a shot
                gameUI.SetArmorText(armor);
                return;
            }
            armor = 0;
            gameUI.SetArmorText(armor); //update the armor text
        }

        //No armor
        health -= healthDamage;
        gameUI.SetHealthText(health);//update health as it change in the UI

        if (health <=0)
        {
            GetComponent<AudioSource>().PlayOneShot(playerDead);
            game.GameOver();
        }
    }

    /// <summary>
    /// Picks the unique items based upon what int is passed into the switch, recall that the int/constants represent the items ID of the pickups.
    /// </summary>
    /// <param name="pickupType">Pickup type.</param>
    public void PickUPItem(int pickupType)
    {
        switch (pickupType)
        {
            case Constants.PickUpArmor:
                pickupArmor();
                break;
            case Constants.PickUpHealth:
                pickupHealth();
                break;
            case Constants.PickUpAssaultRifleAmmo:
                pickupAssaultRilfeAmmo();
                break;
            case Constants.PickUpPistolAmmo:
                pickupPistolAmmo();
                break;
            case Constants.PickUpShotgunAmmo:
                pickupShotgunAmmo();
                break;
            default:
                Debug.LogError("Bad pickup type passed" + pickupType);
                break;
        }

    }

    //1 -- add players health and armor
    private void pickupHealth()
    {
        health += 50;
        if (health > 200)
        {
            health = 200;
        }
        gameUI.SetPickUpText("Health picked up + 50 Health"); //pickup text alert and updates UI health
        gameUI.SetHealthText(health);
    }

    private void pickupArmor()
    {
        armor += 15;
        gameUI.SetPickUpText("Armor picked up + 15 armor");// shows the pickup text alert and updates armor UI
        gameUI.SetArmorText(armor);
    }

    //2 add ammunition types
    private void pickupAssaultRilfeAmmo()
    {
        ammo.AddAmmo(Constants.AssaultRifle, 50);
        //Alert player of the ammunition pickup in the UI. Then we make sure that the active gun matches the assult rifle before setting ammo count.
        // if we didn't do this then the wrong ammo count would be displayed everytime you picked up ammo.
        gameUI.SetPickUpText("Assault rifle ammo picked up + 50 ammo");
        if (gunEquipper.GetActiveWeapon().tag == Constants.AssaultRifle)
        {
            gameUI.SetAmmoText(ammo.GetAmmo(Constants.AssaultRifle));
        }
    }

    private void pickupPistolAmmo()
    {
        ammo.AddAmmo(Constants.Pistol, 20);

        gameUI.SetPickUpText("Pistol ammo picked up + 20 ammo");
        if (gunEquipper.GetActiveWeapon().tag == Constants.Pistol)
        {
            gameUI.SetAmmoText(ammo.GetAmmo(Constants.Pistol));
        }
    }

    private void pickupShotgunAmmo()
    {
        ammo.AddAmmo(Constants.Shotgun, 10);

        gameUI.SetPickUpText("Shotgun ammo picked up + 10 ammo");
        if (gunEquipper.GetActiveWeapon().tag == Constants.Shotgun)
        {
            gameUI.SetAmmoText(ammo.GetAmmo(Constants.Shotgun));
        }
    }

}
