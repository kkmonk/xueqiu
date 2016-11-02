using UnityEngine;
using System.Collections;

public class AnCnt : MonoBehaviour {

    public Animator animator;
	void Start () {
	
	}
	void Update () {
        Time.timeScale = 0.5f;
	
	}
    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.name.Equals("snowBall"))
        {
            animator.SetBool("pz", true);
            Destroy(gameObject, 5f);
        }
    }
}
