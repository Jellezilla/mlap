using UnityEngine;
using System.Collections;

public class WeaponStats : MonoBehaviour {
	
	[HideInInspector]
	public int currentClip;
	public int maxClip;
	[HideInInspector]
	public int currentAmmo;
	public int maxAmmo;
	
	public GameObject gunMuzzle;
	public float spread = 60.0f;
	public int buckshot = 20;
	
	public float reloadTime;
	public float fireRate;
	
	//public Rigidbody projectile;
	public Transform projectile;
	
	public enum Type {
			shotgun, gun };
	
	// Use this for initialization
	void Start () {
//		switch(type) 
//		{	
//			case shotgun:
//				currentClip = maxClip;
//				currentAmmo = maxAmmo;
//			break;
//		
//			case gun: 	
//				Debug.Log ("gun plz");
//			break;
//		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
