using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Health : MonoBehaviour {

	public const int maxHealth = 100;
	public int currentHealth = maxHealth;
	public bool dead;
	public Image healthbar; 
	public Text health;
	public Canvas gameover;
	void Start ()
	{
		dead=false;
		healthbar.fillAmount = 1;
		gameover = GameObject.Find ("game_over").GetComponent<Canvas> ();
		gameover.enabled = false;	
	}
		
	void Update ()// Update is called once per frame
	{
	healthbar.fillAmount = (float)currentHealth / maxHealth;	
	health.text = (healthbar.fillAmount * 100).ToString("000");	
	
	}
	public void TakeDamage(int amount)
	{
		currentHealth -= amount;
		healthbar.fillAmount = (float)currentHealth / maxHealth;
		if (currentHealth <= 0)
		{
			currentHealth = 0;
			Debug.Log("Dead!");
			dead=true;
			gameover.enabled = true;
		}
	}

	public void addhealth(int amount)
	{
		currentHealth += amount;
		if(currentHealth > 100) currentHealth = 100;
		healthbar.fillAmount = (float)currentHealth / maxHealth;
		if (currentHealth <= 0)
		{
			currentHealth = 0;
			Debug.Log("Dead!");
			dead=true;
		}	
	}
}