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
    public Terrain terrain;

    public Material spaceSkyboxMaterial;
    public Material marsSkyboxMaterial;

	// Use this for initialization
	void Start () {
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
            FogGenerators[i].Play();
        }

        terrain.enabled = true;
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
    }
	
    void EndAnimation()
    {
        Destroy(GetComponent<Animator>());
    }

	// Update is called once per frame
	void Update () {
	    
	}
}
