using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour 
{
	public int maxHealth = 30;
	public int currentHealth = 30;
	//public GameObject bullet;
	
	float healthBarLength;
	
	void Start () 
	{
		healthBarLength = Screen.width / 3; 
	}
	void Update () 
	{
		AddjustCurrentHealth(0);
		
//		if(Collision.gameObject.tag == "bullet")
//		{
//			printf("hit!");	
//		}
	}
	void OnGUI() 
	{
		
		GUI.Box(new Rect((Screen.width-healthBarLength), 10, healthBarLength, 20), currentHealth + "/" + maxHealth);
	}
	public void AddjustCurrentHealth(int adj) 
	{

		currentHealth += adj;
		
		if(currentHealth <= 0) 
		{
			currentHealth = 0;
			gameObject.tag = "Untagged";
			Destroy(gameObject);
			//killed();
		}
		if(currentHealth > maxHealth) 
		{
		 currentHealth = maxHealth;
		}
		healthBarLength = ((Screen.width / 2) * (currentHealth / (float)maxHealth))-100;
	// Update is called once per frame
	}
}
