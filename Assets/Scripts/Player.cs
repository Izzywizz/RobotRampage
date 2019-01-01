using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public int health; //the players health
    public int armor; //reduces players health damage by 50% though once it goes, normal damge amount occurs
    public GameUI gameUI; //ref to scripts
    private GunEquipper gunEquipper;
    private Ammo ammo; //reference to ammo class

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
                return;
            }
            armor = 0;
        }

        //No armor
        health -= healthDamage;
        Debug.Log("Heath is " + health);

        if (health <=0)
        {
            Debug.Log("GameOver");
        }
    }
}
