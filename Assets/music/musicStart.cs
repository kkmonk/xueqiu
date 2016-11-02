using UnityEngine;
using System.Collections;

public class musicStart : MonoBehaviour {
	public static bool isPlay=true;
	public AudioSource gameBGM;
	public AudioSource posui;

	// Use this for initialization
	void Start () {
		if (isPlay == true) {
			gameBGM.Play ();
			//posui.Play ();
		}
	}
	// Update is called once per frame
	void Update () {
		if (isPlay == false && gameBGM.isPlaying == true) {
			gameBGM.Stop ();
		}
	}
}
