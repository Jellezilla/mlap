using UnityEngine;
using System.Collections;

public class WeaponShooting : MonoBehaviour 
{
	public GUIStyle myStyle;

	
	public GameObject PrimaryWeapon;
	public GameObject SecondaryWeapon;
	
	
	

	private Animation gunAnim;
	private float nextFire;
	
	
	MyThirdPersonController_Shoulder cs;
	WeaponStats ws;
	
	void Start () 
	{
		cs = GetComponent<MyThirdPersonController_Shoulder>();
		try {
			ws = PrimaryWeapon.GetComponent<WeaponStats>();	
			Restock ();
		} catch(UnassignedReferenceException e) {
		}
			

		
	}
	void FixedUpdate()
	{

	}
	void Update () 
	{

		if(Input.GetButtonDown ("Fire1")) 
		{
			if(ws.currentClip > 0 && Time.time > nextFire) 
			{
				nextFire = Time.time + ws.fireRate;
				Shoot();
				//gunAnim.animation.Play ("Shooting");
	
			}
		}
	
		if(Input.GetKeyDown(KeyCode.R))
		{
			Reload();
		}
		
		if(Input.GetKeyDown (KeyCode.F)) 
		{
			if (PrimaryWeapon != null)  // this is only the case for test shotgun with flashlight. Flashlight needs to be handheld and not attached to a weapon. 
			{
				SwitchFlashlight();
			}
		}

		// -------- Debugging -----------// 

		//cs.aimDir = Quaternion.LookRotation (cs.aimPoint - ws.gunMuzzle.transform.position);
		//Debug.DrawRay(ws.gunMuzzle.transform.position, cs.aimPoint, new Color(1f, 0.922f, 0.015f, 1000f));
		//Debug.DrawLine(ws.gunMuzzle.transform.position, cs.aimPoint);
		//Debug.DrawRay(crosshairRay.origin, crosshairRay.direction, new Color(1f, 0.922f, 0.015f, 1f));
		
		//-------------------------------//
		
	}



	private void SwitchFlashlight() 
	{ 
		Transform flashlight = PrimaryWeapon.transform.Find("Spotlight"); 
		flashlight.light.enabled = !flashlight.light.enabled;
	}
	
	void OnGUI() {
		if (PrimaryWeapon != null && SecondaryWeapon != null)
		{
			ShowAmmo();
		}
	}
	
	void Shoot() 
	{
	//	audio.PlayOneShot(shotSound);
		ws.currentClip--;
	
		
		//GameObject clone = Instantiate (ws.projectile, ws.gunMuzzle.transform.position, cs.aimDir) as GameObject;
		
		//Ray ray = Physics.Raycast
				//Debug.DrawRay(		
		//if(Physics.Raycast(ws.gunMuzzle.transform.position, ws.gunMuzzle.transform.forward, out hit))
		//{
//			Quaternion rot = Quaternion.FromToRotation(Vector3.up, hit.normal);
			for(int i = 0; i < ws.buckshot; i++)
			{
				Debug.Log ("buckshot");
				//Instantiate(projectile, 
			}
		//}
		
	}

					
					
	void Reload() 
	{	
		//if(PrimaryWeapon == shotgun) 
		if(false)
		{
		
			for (int i = ws.currentClip; i < ws.maxClip; i++) 
			{
				ws.currentAmmo--;
				ws.currentClip++;
			}
		} else // for all other weapon types 
		{
			if (ws.currentClip < ws.maxClip)  // is clip full?
			{
				ws.currentAmmo += ws.currentClip;
				//gunAnim.animation.CrossFade("ReloadGun");
	
				if(ws.currentAmmo >= ws.maxClip) // Reload full clip
				{
					StartCoroutine(ReloadWait(ws.maxClip));
									
				} else if(ws.currentAmmo < ws.maxClip) // reload not completely full clip
				{
					StartCoroutine(ReloadWait(ws.currentAmmo));	
				}
			}
		}
	}
	
	public void Restock()
	{
		ws.currentClip = ws.maxClip;
		ws.currentAmmo = ws.maxAmmo;
		//ws.maxAmmo = ws.maxClip + ws.currentAmmo;
	}


	
	void ShowAmmo()
	{
        GUI.Label (new Rect(Screen.width-100, Screen.height -150, 100,25),ws.currentClip+" / "+ws.currentAmmo, myStyle);
	}
	
//	if(gunAnim.animation.isPlaying == false)
//	{
//		gunAnim.animation.CrossFade("Idle");
//	}
	
	IEnumerator ReloadWait(int adj) 
	{
		
		ws.currentClip = 0;
		yield return new WaitForSeconds(ws.reloadTime);	
		
		ws.currentClip = adj;      // put new bullets in current clip.
		ws.currentAmmo -= adj;     // subtract the bullets just put in the clip, from the total amount of bullets.
	}
	
}
