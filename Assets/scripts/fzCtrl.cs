using UnityEngine;
using System.Collections;

public class fzCtrl : MonoBehaviour {

    public Animator animator;
    public Transform sball;
    public AudioSource ms;
    public GameObject child;
    public Animator ps;
    void Start()
    {
        animator = GetComponent<Animator>();
    }
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name.Equals("snowBall"))
        {
            
            if(sball.localScale.x>1f)//球的直径大于一定直径的时候
            {
				if (musicStart.isPlay == true) {
					ms.Play();
				}
                
                animator.SetInteger("ya", 1);
                Destroy(gameObject, Time.deltaTime * 38);
                sball.localScale -= new Vector3(0.05f, 0.05f, 0.05f);
            }
            else
            {
                child.SetActive(true);
                other.gameObject.SetActive(false);
                ps.SetInteger("dead", 1);
                Invoke("yans", 0.2f);
            }
                
            
        }
    }


    public void yans()
    {
        Application.LoadLevel("gameover");
    }
}
