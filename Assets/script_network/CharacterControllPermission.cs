using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Photon;
namespace DestroyIt
{
    public class CharacterControllPermission : PunBehaviour
    {
        public string m_playername;
        // Use this for initialization
        void Start()
        {
            PhotonView ph = gameObject.GetComponent<PhotonView>();
            if (ph != null)
            {
                if (!ph.isMine && PhotonNetwork.connected)
                {
                    gameObject.GetComponent<VechicleController>().enabled = false;
                    gameObject.GetComponent<InputManager>().enabled = false;
                    gameObject.transform.Find("Body/VechicleCamera").gameObject.SetActive(false);
                    gameObject.transform.Find("Body/Main Camera").gameObject.SetActive(false);
                    gameObject.transform.GetChild(0).gameObject.GetComponent<Health>().enabled = false;
                }
                else if (ph.isMine && PhotonNetwork.connected)
                {
                    m_playername = PhotonNetwork.playerName;
                }
            }
        }

        // Update is called once per frame
        void Update()
        {

        }
    }

}