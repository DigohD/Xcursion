using UnityEngine;
using System.Collections;

public class EntryDirector : MonoBehaviour {

    public Camera SceneCamera;
    public int EntryStartDelay = 2;
    public ParticleSystem[] FogGenerators;
    public ParticleSystem EntryFog;
    public GameObject Mars;
    public GameObject Player;
    public GameObject Classroom;
    public GameObject Bot;
    public Terrain terrain;

    public Material spaceSkyboxMaterial;
    public Material marsSkyboxMaterial;

	public Sprite entry, landing;
	public AudioClip AIEntry, AILanding, windClip, atmoClip;
	public AudioSource wind, rockets;

	float startTime;

	// Use this for initialization
	void Start () {
		startTime = Time.time;

        RenderSettings.skybox = spaceSkyboxMaterial;
        RenderSettings.fog = false;

        SceneCamera.GetComponent<Skybox>().material = spaceSkyboxMaterial;

        for (int i = 0; i < FogGenerators.Length; i++)
        {
            FogGenerators[i].Clear();
            FogGenerators[i].Stop();
        }

        terrain.enabled = false;
        //Player modifications
        Player.GetComponent<Rigidbody>().isKinematic = true;
        Light[] playerLights = Player.GetComponentsInChildren<Light>();
        for (int i = 0; i < playerLights.Length; i++)
        {
            playerLights[i].enabled = false;
        }
        //Debug.Log("Skybox removed.");
	}

    void ReverseEdits()
    {
        RenderSettings.skybox = marsSkyboxMaterial;
        RenderSettings.fog = true;

        SceneCamera.GetComponent<Skybox>().material = marsSkyboxMaterial;

        for (int i = 0; i < FogGenerators.Length; i++)
        {
            FogGenerators[i].enableEmission = true;
            FogGenerators[i].Play();
        }

        terrain.enabled = true;
		GameObject missions = GameObject.FindGameObjectWithTag("Mission");
		missions.GetComponent<MissionActivator>().activateMissions();

        //Player modifications
        Player.GetComponent<Rigidbody>().isKinematic = false;
        Light[] playerLights = Player.GetComponentsInChildren<Light>();
        for (int i = 0; i < playerLights.Length; i++)
        {
            playerLights[i].enabled = true;
        }

        Destroy(Mars);
        Classroom.SetActive(false);

        SceneCamera.farClipPlane = 2000;

        //Activate bot entry sequence
        Bot.SetActive(true);
        Bot.GetComponent<BotEntryDirector>().StartSequence();
    }
	
    void EndAnimation()
    {
		rockets.Stop();
		wind.Stop();
		wind.volume = 0.5f;
		wind.clip = windClip;
		wind.Play();
		AILibrary.playAI(AILanding);
		MonitorScript.monitor.sprite = landing;
        Destroy(GetComponent<Animator>());
    }

	bool entryPlayed, atmoPlayed;

	// Update is called once per frame
	void FixedUpdate () {
		float time = Time.time - startTime;

		if(time > 8f && !entryPlayed){
			playEntry();
			entryPlayed = true;
		}

		if(time > 13f && !atmoPlayed){
			wind.PlayOneShot(atmoClip);
			atmoPlayed = true;
		}

		if(time > 16f)
			if(wind.volume > 0.1f)
				wind.volume = wind.volume - 0.0005f;
	}

	void playEntry(){
		AILibrary.playAI(AIEntry);
		MonitorScript.monitor.sprite = entry;
	}
}
