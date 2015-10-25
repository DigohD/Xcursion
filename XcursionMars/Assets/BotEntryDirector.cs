using UnityEngine;
using System.Collections;

public class BotEntryDirector : MonoBehaviour {

	// Use this for initialization
	void Start () {
	    
	}

    public void StartSequence()
    {
        this.gameObject.GetComponent<Animator>().enabled = true;
    }

    void EndSequence()
    {
        Destroy(GetComponent<Animator>());
        this.GetComponent<BotMovement>().enabled = true;
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
