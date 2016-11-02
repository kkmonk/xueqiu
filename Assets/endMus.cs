using UnityEngine;
using System.Collections;

public class endMus : MonoBehaviour {

	public AudioSource posui;

	// Use this for initialization
	void Start () {
		if (musicStart.isPlay == true) {
			posui.Play ();
		}

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
