using UnityEngine;
using System.Collections;

public class Elevator : MonoBehaviour {

	public Transform goalPos;

	static bool activated = false;

	public AudioClip AIWelcome;

	public ChairFollow cf;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(activated){
			Vector3 temp = transform.position;
			transform.position = Vector3.MoveTowards(transform.position, goalPos.position, 0.001f);
			if(cf != null)
				cf.follow(transform.position - temp);
		}

		if(Vector3.Distance(transform.position, goalPos.position) < 0.25f){
			if(cf != null)
				Destroy(cf.gameObject);
		}

		if(Vector3.Distance(transform.position, goalPos.position) < 0.01f){
			ShuttleWindow.activateRot();
			AILibrary.playAI(AIWelcome);
			this.enabled = false;
		}
	}

	public static void activateElevator(){
		activated = true;
	}
}
