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

		if(Input.GetAxis("Horizontal") > 0.1f){
			toApply = Vector3.zero;
			toApply.y = 1 * Input.GetAxis("Horizontal");
			rb.AddTorque(toApply);
		}else if(Input.GetAxis("Horizontal") < -0.1f){
			toApply = Vector3.zero;
			toApply.y = 1 * Input.GetAxis("Horizontal");
			rb.AddTorque(toApply);
		}

		if(Input.GetAxis("Vertical") > 0.1f){
			toApply = Vector3.zero;
			toApply.z = 4 * Input.GetAxis("Vertical");
			rb.AddRelativeForce(toApply);
		}else if(Input.GetAxis("Vertical") < -0.1f){
			toApply = Vector3.zero;
			toApply.z =  4 * Input.GetAxis("Vertical");
			rb.AddRelativeForce(toApply);
		}

		toApply = Vector3.zero;
		toApply.y = forceUp - gravity;

		Vector3 rbVelocity = rb.velocity;
		if(rbVelocity.y > 1f){
			rbVelocity.y = 1f;
		}if(rbVelocity.y < -1f){
			rbVelocity.y = -1f;
		}

		if(rbVelocity.x > 6f){
			rbVelocity.x = 6f;
		}if(rbVelocity.x < -6f){
			rbVelocity.x = -6f;
		}

		if(rbVelocity.z > 6f){
			rbVelocity.z = 6f;
		}if(rbVelocity.z < -6f){
			rbVelocity.z = -6f;
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
