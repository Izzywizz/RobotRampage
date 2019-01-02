using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour {

    void Start()
    {
        DontDestroyOnLoad(gameObject); //This ensures that the GAmeObject that the script it is attached to isn't deleted.
        //this will be reflected in game within the Hierarchy
    }
}
