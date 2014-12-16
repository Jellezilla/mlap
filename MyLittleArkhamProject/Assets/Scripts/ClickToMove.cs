using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ClickToMove : MonoBehaviour {
	
	CharacterController c;
	private float walkSpeed = 2.0f;
	private float runSpeed = 6.0f;
	private float jumpSpeed = 8.0f;
	private float turnSpeed = 10.0f;
	private float curSpeed;
	Vector3 targetPos;
	
	Vector3 moveDir;
	Vector3 rayTest;
	float vSpeed;
	float gravity = 9.8f;
	
	RaycastHit hit = new RaycastHit();
    private Ray ray;
	
	// Use this for initialization
	void Start () 
	{
		curSpeed = runSpeed;
		c = GetComponent<CharacterController>();
		targetPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () 
	{
//		transform.Rotate ();
		moveDir = new Vector3(targetPos.x, vSpeed, targetPos.z);
		moveDir = targetPos - transform.position;
		moveDir = transform.TransformDirection(moveDir);
		c.Move((moveDir.normalized*curSpeed)* Time.deltaTime);
		
		if(c.isGrounded) {
			vSpeed = 0;
			if(Input.GetKeyDown("space")) {
				vSpeed = jumpSpeed;
				print("jump");
			}
		}
		
		ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if(Input.GetKey(KeyCode.Mouse0))
        {
	     	if(Physics.Raycast(ray,out hit))	
			{
				if(hit.collider.tag == "Plane") 
				{
					targetPos = hit.point;
				}				
			}
		}
		
		ApplyGravity();
		
	}
	
	void ApplyGravity() 
	{
		vSpeed -= gravity * Time.deltaTime;
	}
}
