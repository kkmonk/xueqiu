using UnityEngine;
using System.Collections;

public class zanting : MonoBehaviour {

	public AudioSource bgm;
	bool isZanTing;
	void Start () {
		isZanTing = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void Zanting()
	{
		
		if (isZanTing == false) {
			Time.timeScale = 0;
			bgm.mute = true;
			stop.zt = true;
			isZanTing = true;		
		} else {
			Time.timeScale = 1;
			bgm.mute = false;
			isZanTing = false;
			print ("开始");
		}

	}

}
