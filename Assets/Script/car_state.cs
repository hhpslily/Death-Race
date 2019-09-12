using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Hashtable = ExitGames.Client.Photon.Hashtable;
using Photon;

public class car_state : PunBehaviour {

	public wall_manager w;
    public int index;
    private bool locked;
    private float lockedTime;

	// Use this for initialization
	void Start () {
        locked = false;
	}

	// Update is called once per frame
	void Update () {
		if (Mathf.FloorToInt(Time.time - lockedTime) > 1)
        {
            locked = false;
        }
	}

	void OnTriggerEnter(Collider col){
        //print("wallIndex: " + wallIndex);
        //print ("collider wall : ");
        //print (wallIndex);
        if (col.gameObject.name == "Wheel Front Left" || col.gameObject.name == "Wheel Front Right"
                || col.gameObject.name == "Wheel Rear Left" || col.gameObject.name == "Wheel Rear Right")
        {
            if (locked == true)
            {
                print("locked");
                return;
            }
            else
            {
                lockedTime = Time.time;
                locked = true;
            }
			string m_playername = GameObject.Find("GameManager").gameObject.GetComponent<GameManager>().m_playername;
            PhotonPlayer[] players = PhotonNetwork.playerList;
            for (int i = 0; i < players.Length; i++)
            {
                if (players[i].NickName == m_playername)
                {
                    print(m_playername);
                    int round = (int)players[i].CustomProperties["round"];
                    int prev_wall = (int)players[i].CustomProperties["wall_hit"];
                    players[i].SetCustomProperties(new Hashtable() { { "wall_hit", index } });
                    if (prev_wall == 39 && index == 0)
                    {
                        players[i].SetCustomProperties(new Hashtable() { { "round", round + 1 } });
                    }
                    break;
                }
            }
        }
    }
}
