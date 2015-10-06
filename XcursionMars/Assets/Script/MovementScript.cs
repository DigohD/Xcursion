using UnityEngine;
using System.Collections;

public class MovementScript : MonoBehaviour {

	Rigidbody rb;
	Vector3 toApply;
	float upThrottle = 0.04f;
	float gravity = 0.4f;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
		toApply = Vector3.zero;
	}

	// Update is called once per frame
	void FixedUpdate () {
		if(Input.GetKey(KeyCode.D)){
			toApply = Vector3.zero;
			toApply.y = 1;
			rb.AddTorque(toApply);
		}else if(Input.GetKey(KeyCode.A)){
			toApply = Vector3.zero;
			toApply.y = -1;
			rb.AddTorque(toApply);
		}else if(Input.GetKey(KeyCode.W)){
			toApply = Vector3.zero;
			toApply.z = 4;
			rb.AddRelativeForce(toApply);
		}else if(Input.GetKey(KeyCode.S)){
			toApply = Vector3.zero;
			toApply.z = -4;
			rb.AddRelativeForce(toApply);
		}

		toApply = Vector3.zero;
		toApply.y = forceUp - gravity;
		Debug.Log("APPLYING " + (forceUp - gravity));

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
		Debug.Log("ENTER COL");
	}

	void OnTriggerStay(Collider other) {
		forceUp += upThrottle;
	}

	void OnTriggerExit(Collider other) {
		forceUp = 0;
		Debug.Log("LEAVE COL");
	}
}
