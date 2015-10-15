using UnityEngine;
using System.Collections;

public class Scale : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		transform.localScale += new Vector3(0.0003F, 0.0003F, 0.0003F);
	}
}
