using UnityEngine;
using System.Collections;

public class ScanRayScript : MonoBehaviour {

	public ParticleSystem ps;
	bool rayOn = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(!rayOn && Input.GetKeyDown(KeyCode.E)){
			rayOn = true;
			ps.time = 0;
			ps.Play();
		}

		if(rayOn && !ps.isPlaying)
			rayOn = false;

	}
}
