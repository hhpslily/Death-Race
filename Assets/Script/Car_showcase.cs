using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Car_showcase : MonoBehaviour {
	public static int index = 0;
	public GameObject[] car;
	public Canvas setting_canvas;
	public AudioClip buttonSE;
	public AudioSource audioPlayer;
	public Slider slider;
	public Toggle toggle;

	// Use this for initialization
	void Start () {
		setting_canvas = GameObject.Find ("setting_canvas").GetComponent<Canvas> ();
		setting_canvas.enabled = false;		
		audioPlayer = GameObject.Find ("Audio Source").GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void showNextCar(){
		index++;
		if (index > car.Length - 1)
			index = 0;
		for (int i = 0; i < car.Length; i++) 
				car[i].SetActive(false);
		car[index].SetActive(true);
	}

	public void showPreCar(){
		index--;
		if (index < 0)
			index = car.Length - 1;
		for (int i = 0; i < car.Length; i++) 
			car[i].SetActive(false);
		car [index].SetActive (true);
	}

	public void back(){
		UnityEngine.SceneManagement.SceneManager.LoadScene ("scene/start");
	}

	public void start(){
		UnityEngine.SceneManagement.SceneManager.LoadScene ("scene/LobbyScene");
	}

	public void openSettingCanvas(){
		setting_canvas.enabled = true;	
	}

	public void closeSettingCanvas(){
		setting_canvas.enabled = false;	
	}

	public void playSE(){
		audioPlayer.PlayOneShot (buttonSE);
	}

	public void changeVolume(){
		audioPlayer.volume = slider.value;
	}

	public void mute(){
		audioPlayer.mute = toggle.isOn;
	}
		
}
