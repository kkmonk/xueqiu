using UnityEngine;
using System.Collections;
/*音效播放脚本*/
public class musicPlay : MonoBehaviour {

    //public AudioSource music;
    //private GameObject ms;
    void Start()
    {
        //ms=GameObject.FindGameObjectWithTag("musicplayer");
        //music = ms.GetComponent<AudioSource> ();
    }
	void Update () {
	}
	void OnCollisionEnter(Collision other){
		if (string.Equals (other.gameObject.name, "pacman")) {
			//music.Play ();
			Destroy (gameObject);
		}
	}
}
