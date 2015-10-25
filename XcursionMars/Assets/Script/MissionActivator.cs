using UnityEngine;
using System.Collections;

public class MissionActivator : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void activateMissions(){
		foreach(Transform child in transform){
			child.gameObject.SetActive(true);
		}
	}
}
