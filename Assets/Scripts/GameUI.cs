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
    public Image reticle; //Displays the sprite - like the Sprite is a film reel whereas the Image is the film projector. 
    //In this case, you have 3 sprites acting as source image data for the reticle since only 1 will displayed, there is only one image.


    // Use this for initialization
    void Start () {
		
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
}
