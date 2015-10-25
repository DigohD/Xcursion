using UnityEngine;
using System.Collections;

public class TeacherScript : MonoBehaviour {

	Vector3 startPos;

	// Use this for initialization
	void Start () {
		startPos = transform.localPosition;
	}

	float counter;
	int tempcount;

	// Update is called once per frame
	void FixedUpdate () {
		transform.localPosition = startPos + new Vector3(0, Mathf.Sin(counter) / 3, 0);
		counter += 0.01f;

		if(Time.time > 5 && Time.time < 5.2f){
			transform.Rotate(new Vector3(0, 1, 0));
		}

		if(Time.time > 7.7f && Time.time < 7.9f){
			transform.Rotate(new Vector3(0, -1, 0));
		}

		if(Time.time > 9f && tempcount < 90){
			tempcount++;
			transform.Rotate(new Vector3(0, -1, 0));
		}

		if(Time.time > 10f && tempcount < 390){
			tempcount++;
			startPos += new Vector3(0.01f, 0, 0);
		}

		if(Time.time > 13f && tempcount < 525){
			tempcount++;
			transform.Rotate(new Vector3(0, 1, 0));
		}

		if(Time.time > 20f && tempcount < 570){
			tempcount++;
			transform.Rotate(new Vector3(0, 1, 0));
		}

		if(Time.time > 21f && tempcount < 1170){
			tempcount++;
			startPos += new Vector3(-0.01f, 0, 0);
		}

		if(Time.time > 27f && tempcount < 1280){
			tempcount++;
			transform.Rotate(new Vector3(0, -1, 0));
		}

		if(Time.time > 38f && tempcount < 1350){
			tempcount++;
			transform.Rotate(new Vector3(0, -1, 0));
		}

		if(Time.time > 39f && tempcount < 1650){
			tempcount++;
			startPos += new Vector3(0.01f, 0, 0);
		}

		if(Time.time > 42f && tempcount < 1740){
			tempcount++;
			transform.Rotate(new Vector3(0, 1, 0));
		}

		if(Time.time > 45f && tempcount < 1750){
			tempcount++;
			SlidingDoor.activateDoor();
		}
	}
}
