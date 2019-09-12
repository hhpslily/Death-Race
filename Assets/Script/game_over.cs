using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class game_over : MonoBehaviour {


	public Button restart;
	public Button quit;
	// Use this for initialization
	void Start () {
			
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void restart_scene(){
		UnityEngine.SceneManagement.SceneManager.LoadScene ("scene/start");
	}

	public void quit_scene(){
		Application.Quit ();
	}
}
