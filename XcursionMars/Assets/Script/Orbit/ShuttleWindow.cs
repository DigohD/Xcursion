using UnityEngine;
using System.Collections;

public class ShuttleWindow : MonoBehaviour {



	static bool activated = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(transform.localRotation.eulerAngles.y < 10f){
			transform.localEulerAngles = new Vector3(0, 0, 0);
			activated = false;
			this.enabled = false;
			Elevator.decoupleShip();
		}else if(transform.rotation.eulerAngles.y < 360 && activated)
			transform.Rotate(new Vector3(0, -0.1f, 0));
	}

	public static void activateRot(){
		activated = true;
	}
}
