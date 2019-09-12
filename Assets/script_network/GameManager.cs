using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Hashtable = ExitGames.Client.Photon.Hashtable;
using Photon;

public class GameManager : PunBehaviour {

    private GameObject m_vechicle;
    public string m_playername;
    private Vector3[] players_start = new Vector3[4];
    private Vector3 player0_start = new Vector3(-175.0f, -0.02f, -43.0f);
    private Vector3 player1_start = new Vector3(-182.0f, -0.02f, -43.0f);
    private Vector3 player2_start = new Vector3(-175.0f, -0.02f, -55.0f);
    private Vector3 player3_start = new Vector3(-182.0f, -0.02f, -55.0f);
    private PhotonView ph;
    public Text self_rank;
    public Text rank;
    public Text cnt;

    // Use this for initialization
    void Start () {
        players_start[0] = player0_start;
        players_start[1] = player1_start;
        players_start[2] = player2_start;
        players_start[3] = player3_start;
        m_playername = PhotonNetwork.playerName;
        PhotonPlayer[] players = PhotonNetwork.playerList;
        for (int i = 0; i < 4; i++)
        {
            if (players[i].NickName == m_playername)
            {
                int id = (int)players[i].CustomProperties["id"];
                m_vechicle = PhotonNetwork.Instantiate("Vechicle", players_start[id], Quaternion.identity, 0);
                players[i].SetCustomProperties(new Hashtable() { { "round", 1 } });
                players[i].SetCustomProperties(new Hashtable() { { "wall_hit", -1 } });
                players[i].SetCustomProperties(new Hashtable() { { "rank", i } });
                GameObject.Find("map_Camera").gameObject.GetComponent<camera_follow>().player = m_vechicle;
                m_vechicle.gameObject.transform.GetChild(0).GetComponent<Health>().healthbar = GameObject.Find("healthbar").gameObject.GetComponent<Image>();
                m_vechicle.gameObject.transform.GetChild(0).GetComponent<Health>().health = GameObject.Find("health").gameObject.GetComponent<Text>();
                break;
            }
        }
    }
	
	// Update is called once per frame
	void Update () {
        int[] player = new int[4] {0, 0, 0, 0};
        PhotonPlayer[] players = PhotonNetwork.playerList;
        int[] rank_local = new int[4];
		for (int i = 0; i < players.Length; i++) 
		{
			if ((int)players[i].CustomProperties ["round"] == 4) {
				if(players[i].NickName == m_playername)
					UnityEngine.SceneManagement.SceneManager.LoadScene ("scene/escape");
				else
					UnityEngine.SceneManagement.SceneManager.LoadScene ("scene/fail");
			}
		}
        if (PhotonNetwork.isMasterClient)
        {
            for (int i = 0; i < players.Length; i++)
            {
                player[i] = (int)players[i].CustomProperties["round"] * 40 + (int)players[i].CustomProperties["wall_hit"];
                //cnt.text = players[0].NickName + " : "+ (int)players[0].CustomProperties["wall_hit"];
                //self_rank.text = players[1].NickName + " : "+ (int)players[1].CustomProperties["wall_hit"];
            }
            if (player[0] >= player[1] && player[0] >= player[2] && player[0] > player[3])
            {
                rank_local[0] = 0;
                if (player[1] >= player[2] && player[1] >= player[3])
                {
                    rank_local[1] = 1;
                    if (player[2] >= player[3])
                    {
                        rank_local[2] = 2;
                        rank_local[3] = 3;
                    }
                    else 
                    {
                        rank_local[2] = 3;
                        rank_local[3] = 2;
                    }
                }
                else if (player[2] >= player[1] && player[2] >= player[3])
                {
                    rank_local[1] = 2;
                    if (player[1] >= player[3])
                    {
                        rank_local[2] = 1;
                        rank_local[3] = 3;
                    }
                    else 
                    {
                        rank_local[2] = 3;
                        rank_local[3] = 1;
                    }
                }
                else
                {
                    rank_local[1] = 3;
                    if (player[1] >= player[2])
                    {
                        rank_local[2] = 1;
                        rank_local[3] = 2;
                    }
                    else 
                    {
                        rank_local[2] = 2;
                        rank_local[3] = 1;
                    }
                }
            }
            else if (player[1] >= player[0] && player[1] >= player[2] && player[1] > player[3])
            {
                rank_local[0] = 1;
                if (player[0] >= player[2] && player[0] >= player[3])
                {
                    rank_local[1] = 0;
                    if (player[2] >= player[3])
                    {
                        rank_local[2] = 2;
                        rank_local[3] = 3;
                    }
                    else 
                    {
                        rank_local[2] = 3;
                        rank_local[3] = 2;
                    }
                }
                else if (player[2] >= player[0] && player[2] >= player[3])
                {
                    rank_local[1] = 2;
                    if (player[0] >= player[3])
                    {
                        rank_local[2] = 0;
                        rank_local[3] = 3;
                    }
                    else 
                    {
                        rank_local[2] = 3;
                        rank_local[3] = 0;
                    }
                }
                else
                {
                    rank_local[1] = 3;
                    if (player[0] >= player[2])
                    {
                        rank_local[2] = 0;
                        rank_local[3] = 2;
                    }
                    else 
                    {
                        rank_local[2] = 2;
                        rank_local[3] = 0;
                    }
                }
            }
            else if (player[2] >= player[0] && player[2] >= player[1] && player[2] > player[3])
            {
                rank_local[0] = 2;
                if (player[0] >= player[1] && player[0] >= player[3])
                {
                    rank_local[1] = 0;
                    if (player[1] >= player[3])
                    {
                        rank_local[2] = 1;
                        rank_local[3] = 3;
                    }
                    else 
                    {
                        rank_local[2] = 3;
                        rank_local[3] = 1;
                    }
                }
                else if (player[1] >= player[0] && player[1] >= player[3])
                {
                    rank_local[1] = 1;
                    if (player[0] >= player[3])
                    {
                        rank_local[2] = 0;
                        rank_local[3] = 3;
                    }
                    else 
                    {
                        rank_local[2] = 3;
                        rank_local[3] = 0;
                    }
                }
                else
                {
                    rank_local[1] = 3;
                    if (player[0] >= player[1])
                    {
                        rank_local[2] = 0;
                        rank_local[3] = 1;
                    }
                    else 
                    {
                        rank_local[2] = 1;
                        rank_local[3] = 0;
                    }
                }
            }
            else if (player[3] >= player[0] && player[3] >= player[1] && player[3] > player[2])
            {
                rank_local[0] = 3;
                if (player[0] >= player[1] && player[0] >= player[2])
                {
                    rank_local[1] = 0;
                    if (player[1] >= player[2])
                    {
                        rank_local[2] = 1;
                        rank_local[3] = 2;
                    }
                    else 
                    {
                        rank_local[2] = 2;
                        rank_local[3] = 1;
                    }
                }
                else if (player[1] >= player[0] && player[1] >= player[2])
                {
                    rank_local[1] = 1;
                    if (player[0] >= player[2])
                    {
                        rank_local[2] = 0;
                        rank_local[3] = 2;
                    }
                    else 
                    {
                        rank_local[2] = 2;
                        rank_local[3] = 0;
                    }
                }
                else
                {
                    rank_local[1] = 2;
                    if (player[0] >= player[1])
                    {
                        rank_local[2] = 0;
                        rank_local[3] = 1;
                    }
                    else 
                    {
                        rank_local[2] = 1;
                        rank_local[3] = 0;
                    }
                }
            }
            for (int i = 0; i < players.Length; i++)
            {
                players[rank_local[i]].SetCustomProperties(new Hashtable() { { "rank", i } });
                //print("rank " + i + ": " + rank_local[i]);
            }
        }
        string rank0 = "", rank1 = "", rank2 = "", rank3 ="";
        for (int i = 0; i < players.Length; i++)
        {
            int r = (int)players[i].CustomProperties["rank"];
            if (r == 0) rank0 = players[i].NickName;
            else if (r == 1) rank1 = players[i].NickName;
            else if (r == 2) rank2 = players[i].NickName;
            else if (r == 3) rank3 = players[i].NickName;
        }
        rank.text = "1. " + rank0 + "\n2. " + rank1 + "\n3. " + rank2 + "\n4. " + rank3;
        for (int i = 0; i < 4; i++)
        {
            if (players[i].NickName == m_playername)
            {
                int round = (int)players[i].CustomProperties["round"];
                int rank_self = (int)players[i].CustomProperties["rank"] + 1;
                cnt.text = "Round: " + round + "/3";
                self_rank.text = "Rank: " + rank_self + "/4";
                break;
            }
        }
    }
}
