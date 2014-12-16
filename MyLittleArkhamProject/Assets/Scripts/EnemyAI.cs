using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour {
	public Transform target;
	public int moveSpeed;
	public int rotationSpeed;
	
	private int aggro = 15;
	private Transform myTransform;
	
	
	void Awake() {
		myTransform = transform;
	// Use this for initialization
	}
	void Start () {
		//GameObject go = Transform.FindGameObjectWithTag("Player");
			
	//target = go.transform;
	}
	
	// Update is called once per frame
	void Update () {
		float distance = Vector3.Distance(target.transform.position, transform.position);
	//Debug.DrawLine(target.position, myTransform.position, Color.yellow);
	if(distance < aggro+5) {		
		// Look at target
		myTransform.rotation = Quaternion.Slerp(myTransform.rotation, Quaternion.LookRotation(target.position - myTransform.position), rotationSpeed * Time.deltaTime);
		}
	if(distance < aggro) {	
		// Move towards target
		myTransform.position += myTransform.forward * moveSpeed * Time.deltaTime;
	
		}	
	}
}
