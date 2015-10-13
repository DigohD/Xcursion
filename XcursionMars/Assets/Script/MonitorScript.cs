using UnityEngine;
using System.Collections;

public class MonitorScript : MonoBehaviour {

	public static SpriteRenderer monitor;
	
	void Start(){
		monitor = gameObject.GetComponent<SpriteRenderer>();
	}
	
	public static void setMonitor(Sprite newSprite){
		monitor.sprite = newSprite;
	}
}
