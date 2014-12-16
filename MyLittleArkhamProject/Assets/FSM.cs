using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/*	

	Exercise #1:	Our NPC is patroling between a number of wayPoints.
					Add two more wayPoints, and change his route

	Exercise #2:	I have made a variable 'state' for you to use.
					Add a SWITCH-CASE inside the update() function. So you build a FSM.

	Exercise #3:	Change the FSM so: If you get within 10 units of the enemy he should 'charge' you

	Exercise #4:	Change the FSM so: If you get more than 10 units away from enemy he should 'run' back

	Exercise #5:	Change the FSM so: If you get within X units of the enemy he should 'attack' you

	Exercise #6:	Build another FSM inside your FSM (nested FSM). So then he is in attack mode,
					he will switch between 'attack' and a short 'break'

 */

public class FSM : MonoBehaviour {

	private GameObject player;
	
	public List<GameObject> wayPoints;
	public int nextWayPoint = 0;
	public float speed = 10.0f;
	public float chargeSpeed;
	public string state = "patrol";
	
	EnemyHealth eh;
	
	// Use this for initialization
	void Start () 
	{
		chargeSpeed  = speed * 4;
		
		player = GameObject.FindGameObjectWithTag("Player");		
		
		eh = GetComponent<EnemyHealth>();
	}
	
	// Update is called once per frame
	void Update () 
	{
	
		transform.position = new Vector3(transform.position.x, 0, transform.position.z); // stay on ground		
		transform.eulerAngles = new Vector3(transform.eulerAngles.x, 0, transform.eulerAngles.z);
		
		
		switch(state) 
		{
			case "patrol":
				if(Vector3.Distance (transform.position, player.transform.position) < 10)
					state = "charge";
				
				animation.Play("Walk",PlayMode.StopAll);
				if (wayPoints.Count > 0)
				{
					transform.LookAt(wayPoints[nextWayPoint].transform.position);
					transform.position += transform.forward * speed * Time.deltaTime;
					
					if (Vector3.Distance(transform.position,wayPoints[nextWayPoint].transform.position) < 0.5)
					{
						nextWayPoint = (nextWayPoint+1) % wayPoints.Count;
					}
				}
				break;
				
			case "charge":
				
				if(Vector3.Distance (transform.position, player.transform.position) < 3)
					state = "attack";
			
			
				if(Vector3.Distance (transform.position, player.transform.position) > 10)
					state = "patrol";
			
				
				transform.LookAt(player.transform.position);
				animation.Play ("Charge", PlayMode.StopAll);
				transform.position += transform.forward * chargeSpeed * Time.deltaTime;
				break;
			case "attack":
				if(Vector3.Distance (transform.position, player.transform.position) > 3)
					state = "charge";
				animation.Play("Attack");
				break;
			case "flee":
				if(eh.currentHealth < 20)
				{}
				break;
				
		}
	}
}

