using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon;

public class scene_manager : PunBehaviour {

	public AudioClip buttonSE;
	public AudioSource audioPlayer;
	public GameObject obje;
	GameObject obj=null;
	// Use this for initialization
	void Start () {
		obj = GameObject.FindGameObjectWithTag("sound");  
		if (obj==null) {  
			obj = (GameObject)Instantiate(obje);  
		}  
		audioPlayer = GameObject.Find ("Audio Source").GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void gameScene(){
		UnityEngine.SceneManagement.SceneManager.LoadScene ("scene/LobbyScene");
	}

	public void menuScene(){
		UnityEngine.SceneManagement.SceneManager.LoadScene ("scene/menu");
	}

	public void aboutScene(){
		UnityEngine.SceneManagement.SceneManager.LoadScene ("scene/about");
	}
	public void playSE(){
		audioPlayer.PlayOneShot (buttonSE);	
	}

}
