using UnityEngine;
using System.Collections;

public class GateScript : MonoBehaviour {
	GameObject go, gd;
	public string GateLeadingTo;
	// Use this for initialization
	void Start () {
  		go = GameObject.FindWithTag("Player");
		gd = GameObject.FindWithTag ("GameData");
	}
	
	// Update is called once per frame
	void Update () {
		float dist = Vector3.Distance(gameObject.transform.position, go.transform.position);
		
 		if(dist < 10) {	
			Debug.Log ("hej");	
			if(Input.GetKeyDown (KeyCode.E)) 
			{
				Debug.Log (GateLeadingTo);
				Application.LoadLevel(GateLeadingTo);
				DontDestroyOnLoad(gd);
			}
		
		}
			
	}
}
