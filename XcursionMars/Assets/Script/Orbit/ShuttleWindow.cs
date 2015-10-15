using UnityEngine;
using System.Collections;

public class ShuttleWindow : MonoBehaviour {



	static bool activated = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {


		if(transform.localRotation.eulerAngles.z < 10f){
			transform.localEulerAngles = new Vector3(0, 0, 0);
			activated = false;
			this.enabled = false;
		}else if(transform.rotation.eulerAngles.z < 360 && activated)
			transform.Rotate(new Vector3(0, 0, 0.1f));
	}

	public static void activateRot(){
		activated = true;
	}
}
