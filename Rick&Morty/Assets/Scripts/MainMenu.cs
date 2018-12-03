using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	// Use this for initialization
	public void Play () {
        
        SceneManager.LoadScene(1);// start a new game by calling the first scene
    }
	
	// Update is called once per frame
	public void Quit () {
        Application.Quit();
	}

   
}
