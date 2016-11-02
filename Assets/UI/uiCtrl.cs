using UnityEngine;
using System.Collections;

public class uiCtrl : MonoBehaviour {
    public AudioSource play;
    public AudioSource exitGame;
	public AudioSource startBGM;
//	public AudioSource endMusic;
    void Start()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
		if (musicStart.isPlay == true) {
			startBGM.Play ();
		}

    }
	void Update(){
		
		if (musicStart.isPlay == false && startBGM.isPlaying == true) {
			startBGM.Stop ();											//暂停音乐
		} else if (musicStart.isPlay == true && startBGM.isPlaying == false) {	
			startBGM.Play ();											//开启音乐
		}

	}
    public void StartPlay()
    {
		if (musicStart.isPlay == true) {
			play.Play();
		}
        Application.LoadLevelAsync("playGame");
    }
	public void musicButton(){
		if (musicStart.isPlay == false) {
			musicOn ();
			startBGM.Stop ();
		} else {
			musicOFF ();
			startBGM.Stop ();
		}
	}
	public void musicOn(){
		musicStart.isPlay = true;
	}
	public void musicOFF(){
		musicStart.isPlay = false;
	}
    public void ExitGame()
    {
        Application.Quit();
    }
    public void ZhuCaiDan()
    {
        Application.LoadLevel("welcome");
    }
    public void ReStart()
    {
        Application.LoadLevel("playGame");  
    }
	public void AoubtUs()
	{
		Application.LoadLevel ("aboutus");
	}
}
