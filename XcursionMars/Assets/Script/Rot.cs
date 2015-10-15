using UnityEngine;
using System.Collections;

public class Rot : MonoBehaviour {

	public float rotSpeed = 1;

	// Use this for initialization
	void Start () {
		RenderSettings.ambientLight = Color.black;
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(new Vector3(0, 0, rotSpeed * Time.deltaTime));
	}
}
