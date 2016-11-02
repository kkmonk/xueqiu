using UnityEngine;
using System.Collections;

public class dcCtrl : MonoBehaviour {

    public GameObject child;
    public Animator animator;
   

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name.Equals("snowBall"))
        {
            child.SetActive(true);
            other.gameObject.SetActive(false);
            animator.SetInteger("dead", 1);
            Invoke("yans", 0.5f);
            

        }
    }

    public void yans()
    {
        Application.LoadLevel("gameover");
    }
}
