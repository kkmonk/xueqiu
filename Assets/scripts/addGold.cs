using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class addGold : MonoBehaviour {
    
	public Text funshu;
	public AudioSource jinbi;
	void OnTriggerEnter(Collider other)
	{
		if (other.name.Equals ("snowBall")) {
			cnter.goldCnt++;
			int gc = cnter.goldCnt;
			int xc = cnter.xuerenCnt;
			funshu.text="score:"+(gc*100+xc*50);
			Destroy (gameObject);
			if (musicStart.isPlay == true) {
				jinbi.Play ();
			}

		}
		if(other.name.Equals("xie"))
		{
			
		}

	}
}
