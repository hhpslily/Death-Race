using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using UnityEngine.UI;

namespace DestroyIt
{
    public class upanddown : MonoBehaviour
    {
        private bool up;
        public GameObject a;
        Random ran = new Random();
        public Image left_img;
        public Sprite mySI;
        public int weaponType;
        // Use this for initialization
        void Start()
        {
            up = false;
            float i = Random.Range(1.0f, 30.0f);
            //InvokeRepeating("counter", 1.0f, 10.0f + i);


        }

        // Update is called once per frame
        void Update()
        {


        }
        void counter()
        {

            if (up)
            {
                a.SetActive(up);

                up = false;
            }
            else
            {
                a.SetActive(up);

                up = true;

            }

        }
        /*void OnCollisionEnter(Collider col)
        {
            print (col.gameObject.name);
            if(col.gameObject.tag =="Player")
            {
                a.SetActive(false);
            }
        }*/

        void OnTriggerEnter(Collider col)
        {
            if (col.gameObject.name == "Wheel Front Left" || col.gameObject.name == "Wheel Front Right"
                || col.gameObject.name == "Wheel Rear Left" || col.gameObject.name == "Wheel Rear Right")
            {
                string name = PhotonNetwork.playerName;
                GameObject vechicle = col.gameObject.transform.parent.gameObject.transform.parent.gameObject;
                string col_name = vechicle.GetComponent<CharacterControllPermission>().m_playername;
                if (name == col_name)
                {
                    vechicle.GetComponent<InputManager>().GetWeapon(weaponType);
                    a.SetActive(false);
                    left_img.sprite = mySI;
                }
            }
        }
    }
}