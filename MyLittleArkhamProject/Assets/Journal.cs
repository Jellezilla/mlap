using UnityEngine;
using System.Collections;

public class Journal : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetKeyDown(KeyCode.J)) 
		{
			OpenJournal();
		}
	}

	private void OpenJournal() 
	{
		Debug.Log ("Journal opened!");
		Time.timeScale = 0;
	}
}
