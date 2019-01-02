using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //Allows you to manage your scences such as loading, unloading or even searching a scence.

public class Menu : MonoBehaviour {

	public void StartGame () {
        //1 - Loads the main battle scence level
        SceneManager.LoadScene("Battle");
	}

    //2 - exits app, though it only works with standalone builds not within UNity itself
    public void Quit()
    {
        Application.Quit();
    }

    // Update is called once per frame
    void Update () {
		
	}
}
