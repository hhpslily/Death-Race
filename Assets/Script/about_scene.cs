using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class about_scene : MonoBehaviour {

	public AudioClip buttonSE;
	public AudioSource audioPlayer;
	// Use this for initialization
	void Start () {
		audioPlayer = GameObject.Find ("Audio Source").GetComponent<AudioSource>();	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void startscene(){
		UnityEngine.SceneManagement.SceneManager.LoadScene ("scene/start");	
	}

	public void playSE(){
		audioPlayer.PlayOneShot (buttonSE);	
	}
}
