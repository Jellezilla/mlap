using UnityEngine;
using System.Collections;

public class Investigator : MonoBehaviour {
	

	public string Name;
	public string Title;
	private int age;
	private string home;

	private int stamina;
	private int sanity;

	private int focus;


	private int speed;
	private int sneak;

	private int fight;
	private int will;

	private int lore;
	private int luck;

	private GameObject equipped;

	private bool showItemGUI = false; 
	private string ItemGUI;
	public float offsetY;
	public Texture2D crosshair;
	// Use this for initialization
	void Start () 
	{
		Screen.lockCursor = true;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetKeyDown(KeyCode.G)) 
		{
			DropItem();
		}
		if(Input.GetKeyDown(KeyCode.E))
		{
			PickUpItem();
		}
		Vector3 fwd = Camera.main.transform.TransformDirection(Vector3.forward); // transform.TransformDirection(Vector3.forward);
		RaycastHit hit;
		
//		if(Physics.Raycast(Camera.main.transform.position, fwd,out hit)) 
//		{
//			Debug.DrawLine (Camera.main.transform.position, hit.transform.position);
//			float distanceToObject = hit.distance;
//			if(distanceToObject < 8 && hit.transform.renderer.isVisible) 
//			{
//				ItemGUI = "Pick up " + hit.transform.name + " - Press 'E' key.";
//				showItemGUI = true;
//			} else {
//				showItemGUI = false;
//			}
//		}



	}

	void OnGUI() 
	{
		ApplyCrosshair();
		if(showItemGUI)
		{
			GUI.Label(new Rect(Screen.width/2-100,Screen.height/2-100,200,25), ItemGUI);
		}
	}

	void ExplosionDamage(Vector3 center, float radius) {

		Collider[] hitColliders = Physics.OverlapSphere(center, radius);

		int i = 0;
		while (i < hitColliders.Length) {
			//hitColliders[i].SendMessage("AddDamage");

			if(hitColliders[i].tag == "CommonItem")
				Debug.Log ("Common item in vicinity. Press 'G' to pick up");

			i++;
		}
	}

	private void PickUpItem() 
	{

		ExplosionDamage(transform.position, 15);




//		Vector3 fwd = Camera.main.transform.TransformDirection(Vector3.forward); // transform.TransformDirection(Vector3.forward);
//		RaycastHit hit;
//	
//		if(Physics.Raycast(Camera.main.transform.position, fwd,out hit)) 
//		{
//			float distanceToObject = hit.distance;
//			if(distanceToObject < 6 && hit.transform.tag == "CommonItem") 
//			{
//				Debug.Log ("CommonItem");
//			}
//			Debug.Log ("Object hit: + " + hit.transform.name);
//		}
		// check if in range
		// destroy gameobject
		// add item to inventory 
		// check for autoequip -> autoequip()
		// 
	}

	
	private void DropItem() 
	{
		equipped = null;
		// find equipped object
		// set unequip
		// remove from inventory
		// instantiate in vicinity
		
		
	}
	private void SelectPreviousItem() 
	{

	}

	void ApplyCrosshair() 
	{	
		float middleScreenX = Screen.width / 2;
		float middleScreenY = Screen.height / 2;
		// xxx hvis nedenstående x værdi er minus 20, skal offsetY så ikke også have trukket 20 fra?
		Rect aimPos = new Rect(middleScreenX-20, middleScreenY-offsetY, 20, 20);
		GUI.DrawTexture(aimPos, crosshair);	
	}
}
