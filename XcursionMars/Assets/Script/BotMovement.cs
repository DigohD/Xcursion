using UnityEngine;
using System.Collections;

public class BotMovement : MonoBehaviour {

	Rigidbody rb;
	Vector3 toApply;
	float upThrottle = 0.04f;
	float gravity = 0.4f;

	bool forward, backward, left, right;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
		toApply = Vector3.zero;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		int action = Random.Range(1, 400);
		switch(action){
			case 1:
				forward = true;
				break;
			case 2:
				forward = true;
				break;
			case 3:
				left = true;
				break;
			case 4:
				right = true;
				break;
			case 5:
			case 6:
			case 7:
			case 8:
				forward = false;
				backward = false;
				left = false;
				right = false;
				break;

		}


		if(right){
			toApply = Vector3.zero;
			toApply.y = 1;
			rb.AddTorque(toApply);
		}else if(left){
			toApply = Vector3.zero;
			toApply.y = -1;
			rb.AddTorque(toApply);
		}else if(forward){
			toApply = Vector3.zero;
			toApply.z = 4;
			rb.AddRelativeForce(toApply);
		}else if(backward){
			toApply = Vector3.zero;
			toApply.z = -4;
			rb.AddRelativeForce(toApply);
		}
		
		toApply = Vector3.zero;
		toApply.y = forceUp - gravity;
		
		Vector3 rbVelocity = rb.velocity;
		if(rbVelocity.y > 0.5f){
			rbVelocity.y = 0.5f;
		}if(rbVelocity.y < -0.5f){
			rbVelocity.y = -0.5f;
		}
		
		if(rbVelocity.x > 3f){
			rbVelocity.x = 3f;
		}if(rbVelocity.x < -3f){
			rbVelocity.x = -3f;
		}
		
		if(rbVelocity.z > 3f){
			rbVelocity.z = 3f;
		}if(rbVelocity.z < -3f){
			rbVelocity.z = -3f;
		}
		rb.velocity = rbVelocity;
		
		rb.AddForce(toApply);
	}
	
	float forceUp = 0;
	
	void OnTriggerEnter(Collider other) {;

	}
	
	void OnTriggerStay(Collider other) {
		forceUp += upThrottle;
	}
	
	void OnTriggerExit(Collider other) {
		forceUp = 0;

	}
}
