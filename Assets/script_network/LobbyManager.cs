using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI ;
using Hashtable = ExitGames.Client.Photon.Hashtable;

using Photon;

public class LobbyManager : PunBehaviour {

    public GameObject startConnectPanel;
    public GameObject lobbyPanel;
    public GameObject roomPlayerPanel;
    //public GameObject roomPanel;

    public GameObject roomManager;

    private string m_playerName = "Player";
    private RoomManager m_roomManager = null;

    void Awake()
    {
        PhotonNetwork.autoJoinLobby = true;
        PhotonNetwork.logLevel = PhotonLogLevel.Full;
        PhotonNetwork.automaticallySyncScene = true;       
    }

	// Use this for initialization
	void Start () {
        m_roomManager = roomManager.GetComponent<RoomManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void connect()
    {
        // Get Player Name from Input and then set player name
        m_playerName = startConnectPanel.GetComponentInChildren<InputField>().text;
        PhotonNetwork.playerName = m_playerName;
        // Set Application version of program
        PhotonNetwork.ConnectUsingSettings("1.0.0");
    }
    public override void OnJoinedLobby()
    {        
        // Change interface to Lobby Panel
        startConnectPanel.SetActive(false);
        lobbyPanel.SetActive(true);
    }

    public void disconnect() {
        PhotonNetwork.Disconnect(); 
    }
    public override void OnDisconnectedFromPhoton()
    {
        // Change interface to Start Connect Panel
        startConnectPanel.SetActive(true);
        lobbyPanel.SetActive(false);
    }

    public void createMatch()
    {
        RoomOptions options = new RoomOptions();
        options.MaxPlayers = 4;
        string roomName = m_playerName + "'s Room";
        if (!PhotonNetwork.CreateRoom(roomName, options, TypedLobby.Default))
        {
            // The Room Name is already existed
        }
    }
    public override void OnJoinedRoom()
    {
        // Change to Room Panel
        lobbyPanel.SetActive(false);
        //roomPanel.SetActive(false);
        roomPlayerPanel.SetActive(true);

        this.updatePlayerList();
    }
    public override void OnPhotonPlayerConnected(PhotonPlayer newPlayer)
    {
        this.updatePlayerList(); 
    }
    public override void OnPhotonPlayerDisconnected(PhotonPlayer otherPlayer)
    {
        this.updatePlayerList();
    }
    private void updatePlayerList()
    {
        if (PhotonNetwork.inRoom)
        {
            PhotonPlayer[] players = PhotonNetwork.playerList;
            // Have already defined Maximum number of players is 4
            for (int i = 0; i < 4; i++){
                if (i < players.Length){
                    // Classify Master & Client
                    if (players[i].IsMasterClient){
                        m_roomManager.setPlayerTag(i, players[i].NickName + " [Master]");
                    }
                    else{
                        m_roomManager.setPlayerTag(i, players[i].NickName);
                    }
                }
                else{
                    m_roomManager.setPlayerTag(i, "Waiting");
                }
            }
        }
    }

    public void quickMatch()
    {
        PhotonNetwork.JoinRandomRoom();
    }
    public override void OnPhotonRandomJoinFailed(object[] codeAndMsg)
    {
        // Create a room
        this.createMatch();        
    }

    public void selectRoom()
    {
        // Change Panel
        lobbyPanel.SetActive(false);
        //roomPanel.SetActive(true);

        this.UpdateRoomList();
    }
    private void UpdateRoomList()
    {
        if (PhotonNetwork.insideLobby)
        {
            RoomInfo[] rif = PhotonNetwork.GetRoomList();
            // Clear RoomList first
            m_roomManager.clearRooms();
            // For Simplify the program, We just display 4 existed rooms if number of rooms > 4
            for (int i = 0; i < rif.Length; i++)
            {
                if (i >= 4)
                    break;

                m_roomManager.setRoomSelection(i, rif[i].Name);
            }
        }
    }

    public void joinToSpecifyRoom(string roomName)
    {
        if (PhotonNetwork.JoinRoom(roomName))
        {
            Debug.Log("Join Complete!");
        }
        else
        {
            Debug.Log("Join Failed!");
        }
    }

    public void startMatch()
    {
        if (PhotonNetwork.isMasterClient) {
            PhotonPlayer[] players = PhotonNetwork.playerList;
            for (int i = 0; i < players.Length; i++)
            {
                players[i].SetCustomProperties(new Hashtable() { { "id", i } });
            }
            PhotonNetwork.LoadLevel("game");
        }
    }
    public void leaveMatch()
    {
        PhotonNetwork.LeaveRoom();
    }
    public override void OnLeftRoom()
    {
        roomPlayerPanel.SetActive(false);
        //roomPanel.SetActive(false);

        lobbyPanel.SetActive(true);
    }
}
