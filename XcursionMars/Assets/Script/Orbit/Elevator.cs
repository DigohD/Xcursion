using UnityEngine;
using System.Collections;

public class Elevator : MonoBehaviour {

	public GameObject shuttle;

	public Transform goalPos;

	static bool activated = false;

	public AudioClip AIWelcome, AIDecouple, elevatorClip;
	public Sprite welcome, decouple;

	public ChairFollow cf, fellow;

	static bool glassClosed;

	public AudioSource engineAmbient, rockets, elevator;

	// Use this for initialization
	void Start () {
	
	}

	bool first;
	bool second;
	bool elevatorPlayed = false;

	// Update is called once per frame
	void FixedUpdate () {
		if(second)
			return;

		if(activated && !elevatorPlayed){
			elevator.PlayOneShot(elevatorClip);
			elevatorPlayed = true;
		}

		if(activated){
			Vector3 temp = transform.position;
			transform.position = Vector3.MoveTowards(transform.position, goalPos.position, 0.01f);
			if(cf != null){
				cf.follow(transform.position - temp);
				fellow.follow((transform.position - temp) / 1.5f);
			}
		}

		if(Vector3.Distance(transform.position, goalPos.position) < 0.25f){
			if(cf != null)
				Destroy(cf.gameObject);
		}

		if(Vector3.Distance(transform.position, goalPos.position) < 0.01f && !first){
			ShuttleWindow.activateRot();
			transform.parent = shuttle.transform;

			AILibrary.playAI(AIWelcome);
			MonitorScript.monitor.sprite = welcome;
			engineAmbient.Play();

			first = true;
		}

		if(glassClosed && !second){
			AILibrary.playAI(AIDecouple);
			MonitorScript.monitor.sprite = decouple;

			shuttle.GetComponent<Animator>().enabled = true;
			shuttle.GetComponent<EntryDirector>().enabled = true;

			rockets.Play ();

			second = true;
		}
	}
	
	public static void activateElevator(){
		activated = true;
	}

	public static void decoupleShip(){
		glassClosed = true;
	}
}
