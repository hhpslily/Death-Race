using UnityEngine;
using System.Collections;
using System; //#1
using UnityEngine.UI;

public class timer : MonoBehaviour 
{
	public Text time;
	float start_time;
	float now_time;

	void Start()
	{
		start_time = Time.time;
	}

	void Update () 
	{  	
			show_time();
	}
	
	void show_time (){
		now_time = Time.time - start_time;
		time.text = Math.Floor(now_time/60).ToString("00") + ":" + (now_time%60).ToString("00.00");
	}


}
