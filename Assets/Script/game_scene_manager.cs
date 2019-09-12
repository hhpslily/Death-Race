using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class game_scene_manager : MonoBehaviour {

	public AudioClip buttonSE;
	public AudioSource audioPlayer;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void gameScene(){
		UnityEngine.SceneManagement.SceneManager.LoadScene ("scene/LobbyScene");
	}

	public void quit(){
		Application.Quit();
	}

	public void playSE(){
		audioPlayer.PlayOneShot (buttonSE);	
	}

	public void startscene(){
		UnityEngine.SceneManagement.SceneManager.LoadScene ("scene/start");	
	}
}
