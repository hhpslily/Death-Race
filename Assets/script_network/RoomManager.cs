using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class RoomManager : MonoBehaviour {

    public GameObject roomPlayerInterface;
    public List<GameObject> roomList;

    private Text[] m_playerNameTags;

    // Use this for initialization
	void Start () {
        m_playerNameTags = roomPlayerInterface.GetComponentsInChildren<Text>();
        for (int i = 0; i < roomList.Count; i++)
        {
            roomList[i].GetComponent<RoomSelectionBehaviour>().init();
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void setPlayerTag(int idx, string name)
    {
        if (idx >= 0 && idx < m_playerNameTags.Length)
        {
            m_playerNameTags[idx].text = name;
        }
    }

    public void setRoomSelection(int idx, string roomName)
    {
        if (idx >= 0 && idx < roomList.Count)
        {
            roomList[idx].GetComponent<RoomSelectionBehaviour>().setRoomName(roomName);
        }
    }
    public void clearRooms()
    {
        for (int i = 0; i < roomList.Count; i++)
        {
            roomList[i].GetComponent<RoomSelectionBehaviour>().reset();
        }
    }
}
