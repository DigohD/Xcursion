using UnityEngine;
using System.Collections;

public class AILibrary : MonoBehaviour {

	public static AudioSource AI;

	void Start(){
		AI = gameObject.GetComponent<AudioSource>();
	}

	public static void playAI(AudioClip clip){
		AI.Stop();
		AI.PlayOneShot(clip);
	}
}
