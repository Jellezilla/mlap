﻿using UnityEngine;
using System.Collections;

public class FloorTrigger : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter(Collider col)
	{
		
		if(col.gameObject.tag == "Player") 
		{ 
			Debug.Log ("lame");
		}
		
	}
		
}
