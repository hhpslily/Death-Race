using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using UnityEngine.EventSystems;

public class RoomSelectionBehaviour : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler {

    private string m_roomName;
    private GameObject m_enterHintPanel;
    private GameObject m_prepareHintPanel;

    private bool m_prepareFlag = true;

	// Use this for initialization
	void Start () {
       
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void init()
    {
        m_enterHintPanel = gameObject.transform.Find("EnterPanel").gameObject;
        m_enterHintPanel.SetActive(false);

        m_prepareHintPanel = gameObject.transform.Find("PreparePanel").gameObject;
        m_prepareHintPanel.SetActive(false);

        gameObject.GetComponentInChildren<Text>().text = "NA";

        m_prepareFlag = false;
    }
    public void reset()
    {
        m_prepareFlag = true;
        gameObject.GetComponentInChildren<Text>().text = "NA";

    }
    public void setRoomName(string roomName)
    {
        m_roomName = roomName;
        gameObject.GetComponentInChildren<Text>().text = m_roomName;
        m_prepareFlag = false;
    }

    public void OnPointerClick(PointerEventData e)
    {
        LobbyManager lm = GameObject.FindObjectOfType<LobbyManager>();
        if (lm != null && !m_prepareFlag)
        {
            lm.joinToSpecifyRoom(m_roomName);
        }
    }

    public void OnPointerEnter(PointerEventData e)
    {
        if (m_prepareFlag)
        {
            m_prepareHintPanel.SetActive(true);
        }
        else
        {
            m_enterHintPanel.SetActive(true);
        }
       
    }

    public void OnPointerExit(PointerEventData e)
    {        
        m_enterHintPanel.SetActive(false);
        m_prepareHintPanel.SetActive(false);
    }

    
}
