using UnityEngine;
using System.Collections;
using System.IO;

public class Screenshot : MonoBehaviour {

    string rootFilename = "C:\\Users\\Kinan\\Desktop\\Screenshots\\Screenshot";
    string extension = ".png";

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if(Input.GetButtonUp("Fire1"))
        {
            int counter = 0;
            do
            {
                counter++;
            } while (File.Exists(rootFilename + counter + extension));
            Application.CaptureScreenshot(rootFilename + counter + extension);
            Debug.Log("Screenshot " + rootFilename + counter + extension + " taken.");
        }
	}
}
