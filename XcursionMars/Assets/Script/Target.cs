using UnityEngine;
using System.Collections;

public class Target : MonoBehaviour {

	public Sprite monitorSprite;
	public AudioClip informationAI;

	public Sprite getMonitorSprite(){
		return monitorSprite;
	}

	public AudioClip getAudio(){
		return informationAI;
	}
}
