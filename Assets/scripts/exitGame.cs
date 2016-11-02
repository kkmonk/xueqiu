using UnityEngine;
using System.Collections;

public class exitGame : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if(Application.platform==RuntimePlatform.Android && Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
	}
}
