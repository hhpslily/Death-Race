using UnityEngine;
using System.Collections;

public class Bullet0 : MonoBehaviour {

	void Start ()
	{
		
			
	}
 
	 // Update is called once per frame
	void Update ()
	{
		
		
	}
	void OnCollisionEnter(Collision collision)
	{
		//var health = collision.gameObject.GetComponent<Health>();
		print ("000000"+collision.gameObject.name);
		Debug.Log("---------!");
		//if(collision.gameObject.tag =="Player")
		{
			if(collision.gameObject.GetComponent<Health>()!=null)
			//if (health != null)
			{
				collision.gameObject.GetComponent<Health>().TakeDamage(10);
				//health.TakeDamage(10);
			}
		}
	}
}