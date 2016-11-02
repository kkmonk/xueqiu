using UnityEngine;
using System.Collections;

public class AnimatorController : MonoBehaviour {

    private bool isCollided=false;
    public Animator am;
    void OnCollisionEnter(Collision other)
    {
        if(string.Equals(other.gameObject.name,"snowBall"))
        {
            print("发生碰撞了");
            isCollided = true;
            am.SetBool("isCollision", isCollided);
            other.gameObject.transform.localScale *= 2;
        }
    }
}
