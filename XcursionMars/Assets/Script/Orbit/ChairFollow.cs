using UnityEngine;
using System.Collections;

public class ChairFollow : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void follow(Vector3 delta){
		transform.position += delta;
	}
}
