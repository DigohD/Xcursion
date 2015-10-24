using UnityEngine;
using System.Collections;

public class TargetMarker : MonoBehaviour {

	public float rotSpeed;
	public Vector3 referencePos;

	// Use this for initialization
	void Start () {
		referencePos = transform.localPosition;
	}

	int counter = 0;

	// Update is called once per frame
	void Update () {

	}

	void FixedUpdate(){
		transform.Rotate(new Vector3(0, rotSpeed * Time.deltaTime, 0));
		transform.localPosition = referencePos + new Vector3(0, Mathf.Sin(counter * 3 * Time.deltaTime), 0);
		counter++;
	}
}
