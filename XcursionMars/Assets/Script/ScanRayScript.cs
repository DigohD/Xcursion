using UnityEngine;
using System.Collections;

public class ScanRayScript : MonoBehaviour {

	public ParticleSystem ps;
	bool rayOn = false;

	public AudioClip scanFailure;
	public Sprite monitorScanFailure;

	Sprite monitorSprite;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(!rayOn && (Input.GetKeyDown(KeyCode.E) || Input.GetButtonDown("Fire3"))){
			rayOn = true;
			scan ();
			ps.time = 0;
			ps.Play();
		}

		if(rayOn && !ps.isPlaying)
			rayOn = false;

	}

	private bool scan()
	{
		RaycastHit hit;
		RaycastHit[] hits = Physics.RaycastAll(ps.transform.position, ps.transform.forward);

		for(int i = 0; i < hits.Length; i++){
			GameObject scanned = hits[i].collider.gameObject;
			Debug.LogWarning("HIT: " + scanned.name);
			if(scanned.tag.Equals("Target")){
				Debug.LogWarning("Target hit: " + scanned.name);
				Target ts = scanned.GetComponent<Target>();
				AILibrary.playAI(ts.getAudio());
				MonitorScript.setMonitor(ts.getMonitorSprite());
			}
			return true;
		}

		AILibrary.playAI(scanFailure);
		MonitorScript.setMonitor(monitorScanFailure);
		return false;
	} 
}
