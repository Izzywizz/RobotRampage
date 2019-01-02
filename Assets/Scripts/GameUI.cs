using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour {

    [SerializeField] //attribute - runtime variable accessible from Unity Inspector NOT from other scripts
    Sprite redReticle; //sprite represents an imported texutre (for use of in a 2D game based or UI)
    [SerializeField]
    Sprite yellowReticle; //we are able to add texture types in the inspector bc they are sprites
    [SerializeField]
    Sprite blueReticle;
    public Image reticle;
    //Displays the sprite - like the Sprite is a film reel whereas the Image is the film projector. 
    //In this case, you have 3 sprites acting as source image data for the reticle since only 1 will displayed, there is only one image.

    //Game UI fields - These are references to the UI elements created earlier using UI > TExt 
    [SerializeField]
    private Text ammoText;
    [SerializeField]
    private Text healthText;
    [SerializeField]
    private Text armorText;
    [SerializeField]
    private Text scoreText;
    [SerializeField]
    private Text pickupText;
    [SerializeField]
    private Text waveText;
    [SerializeField]
    private Text enemyText;
    [SerializeField]
    private Text waveClearText;
    [SerializeField]
    private Text newWaveText;
    [SerializeField]
    Player player;


    // Use this for initialization
    void Start () {
        //1 - init the players health and ammunition text;
        SetArmorText(player.armor);
        SetHealthText(player.health);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void UpdateReicle()
    {
        //This SWITCH will change the sprite to reflect the active gun
        switch(GunEquipper.activeWeaponType)
        {
            case Constants.Pistol:
                reticle.sprite = redReticle;
                break;
            case Constants.Shotgun:
                reticle.sprite = yellowReticle;
                break;
            case Constants.AssaultRifle:
                reticle.sprite = blueReticle;
                break;
            default:
                return;
        }
    }

    //2 - simple setters for the relevant ui text
    public void SetArmorText(int armor)
    {
        armorText.text = "Armor: " + armor;
        Debug.Log("Armor : " + armor);
    }

    public void SetHealthText(int health)
    {
        healthText.text = "Health: " + health;
    }

    public void SetAmmoText(int ammo)
    {
        ammoText.text = "Ammo: " + ammo;
    }

    public void SetScoreText(int score)
    {
        scoreText.text = "" + score;
    }

    public void SetWaveText(int time)
    {
        waveText.text = "Next Wave: " + time;
    }

    public void SetEnemyText(int enemies)
    {
        enemyText.text = "Enemies: " + enemies;
    }

    //We will use coroutines to display text for few moments which is ideal use case for coroutines
    //1 Show the wave clear bonus text by settings its enaabled stated to true, then immediately call a coroutine that will hide the text.
    // Remember that the coroutine pauses betweeen frames and thus will wait 4 seconds before hiding itself again
    public void ShowWaveClearBonus()
    {
        waveClearText.GetComponent<Text>().enabled = true;
        StartCoroutine("hideWaveClearBonus");
    }

    //2 - Wait 4 seconds before hiding the text
    IEnumerator hideWaveClearBonus()
    {
        yield return new WaitForSeconds(4);
        waveClearText.GetComponent<Text>().enabled = false;
    }

    //3 Enable and set the texst for the pickup and restart the hidePickup corrotine, allowing the player to pickup 2 or more pickups quickly
    // without disrupting the first pickup text being displayed, as the second pickup would of obsecured the first
    public void SetPickUpText(string text)
    {
        pickupText.GetComponent<Text>().enabled = true;
        pickupText.text = text;
        //Restart the coroutine so it doesn't end early
        StopCoroutine("hidePickupText");
        StartCoroutine("hidePickupText");
    }

    //4 - wati 4 seconds to remove the text
    IEnumerator hidePickupText()
    {
        yield return new WaitForSeconds(4);
        pickupText.GetComponent<Text>().enabled = false;
    }

    //5 - show the new wav e text
    public void ShowNewWaveText()
    {
        StartCoroutine("hideNewWaveText");
        newWaveText.GetComponent<Text>().enabled = true;
    }

    //6 - wait 3 secs then hide it,
    IEnumerator hideNewWaveText()
    {
        yield return new WaitForSeconds(4);
        newWaveText.GetComponent<Text>().enabled = false;
    }
}
