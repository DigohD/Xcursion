using UnityEngine;
using System.Collections;

public class SlidingDoor : MonoBehaviour {

	static bool activated = true;
	
	// Use this for initialization
	void Start (){
		
	}

	int stacks = 0;
	// Update is called once per frame
	void FixedUpdate () {
		if(activated){
			transform.Translate(0.001f, 0, 0);
			stacks++;
		}

		if(stacks > 200){
			Elevator.activateElevator();
			this.enabled = false;
		}
	}
	
	public static void activateDoor(){
		activated = true;
	}
}
