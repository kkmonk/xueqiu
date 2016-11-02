using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class snCtrl : MonoBehaviour {
    public Animator animator;
    AudioSource ms;
	public Text fenshu;
    void Start()
    {
        animator = GetComponent<Animator>();
        ms = GetComponent<AudioSource>();
    }
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name.Equals("snowBall"))
        {
           // print("yes");
            animator.SetInteger("pz", 1);
			if (musicStart.isPlay == true) {
				ms.Play ();
			}
            ms.volume = 3f;
            if(other.gameObject.transform.localScale.x<3f)
                other.gameObject.transform.localScale += new Vector3(0.2f, 0.2f, 0.2f);
            Destroy(gameObject, Time.deltaTime * 80);
			int xc;
			int gc;
			xc= ++cnter.xuerenCnt;
			gc = cnter.goldCnt;
			fenshu.text="score:"+(gc*100+xc*50);
		}

    }

}
