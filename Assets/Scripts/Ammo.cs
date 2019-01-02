using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections.Generic;

public class Ammo : MonoBehaviour {

    [SerializeField]
    GameUI gameUI;

    [SerializeField]
    private int pistolAmmo = 20;
    [SerializeField] 
    private int shotgunAmmo = 10;
    [SerializeField]
    private int assaultRifleAmmo = 50;

    private Dictionary<string, int> tagToAmmo; // a dict which maps a guns type which is string to its ammo count, an int

    private void Awake()
    { //Awake is called before start, init the dict prevents any null even before using the standard Start method
        tagToAmmo = new Dictionary<string, int>
        { //Each gun type becomes a key and the key's value is the appropiate ammo type
            { Constants.Pistol, pistolAmmo },
            { Constants.Shotgun, shotgunAmmo },
            { Constants.AssaultRifle, assaultRifleAmmo },
        };

    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    /*
     * Though these methods seem like overkill, when you go to add a new ammunition type, you only need to add it to the dict
     * bc with these helper methods you just pass in the tag and it does the rest, so you wouldnt have to create indivudal getters and setters
     * for everything
     */

    public void AddAmmo(string tag, int ammo)
    {
        if (!tagToAmmo.ContainsKey(tag))
        {
            Debug.LogError("Unrecognized gun type passed: " + tag);
        }
        tagToAmmo[tag] += ammo; //this will add ammounition to the appropaite gun type. tagToAmmo[Shotgun] += 20 for example
        //if you;ve passed in an unrecognized bad gun type, you log it as an error.
    }

    /// <summary>
    ///  returns true if gun has ammo (at least 1 bullet left) False if it doesnt
    /// </summary>
    /// <returns><c>true</c>, if ammo present, <c>false</c> otherwise false.</returns>
    /// <param name="tag">Tag.</param>
    public bool HasAmmo(string tag)
    {
        if (!tagToAmmo.ContainsKey(tag))
        {
            Debug.LogError("Unreognized gun type passed: " + tag);
        }

        return tagToAmmo[tag] > 0;
    }

    /// <summary>
    /// Return bullet count for a gun type.
    /// </summary>
    /// <returns>The ammo.</returns>
    /// <param name="tag">Tag.</param>
    public int GetAmmo(string tag)
    {
        if (!tagToAmmo.ContainsKey(tag))
        {
            Debug.LogError("Unregnized gun type passed: " + tag);
        }

        return tagToAmmo[tag]; //returns value for specified tag key
    }

    /// <summary>
    /// Checks for correct <paramref name="tag"/>, if it finds the appropiate ammunition it then subtracts a bullet.
    /// </summary>
    /// <param name="tag">Tag.</param>
    public void ConsumeAmmo(string tag)
    {
        if(!tagToAmmo.ContainsKey(tag))
        {
            Debug.LogError("Unrecognized gun type passed: " + tag);
        }
        tagToAmmo[tag]--;
        gameUI.SetAmmoText(tagToAmmo[tag]); //updates the UI each time the user fires their weapon.
    }
}


