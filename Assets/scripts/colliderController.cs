using UnityEngine;
using System.Collections;
/*
 * 此脚本实现碰撞后的各种逻辑
 */
public class colliderController : MonoBehaviour {

    public Animator animator;
    public GameObject child;
    void OnCollsionEnter(Collision other)
    {
        int a=0;
        string name = other.gameObject.name;
        if (string.Equals(name,"dici"))
        {
            /*碰到的是地刺，死亡*/
            a++;
        }
        if (string.Equals(name,"fangzi"))
        {
            //if(雪球比房子大，破坏并播放动画效果)
            //else 死亡
            a++;
        }
        if(string.Equals(name,"snowMan"))
        {
            //雪球的体积变大,同时雪人消失
            a++;
        }
        if (string.Equals(name,"gold"))
        {
            //需播放动画
            a++;
        }
        
        //最后总是要把碰到的障碍物销毁
        //Destroy(other.gameObject);        

    }
    void Start()
    {
        //child = GameObject.FindGameObjectWithTag("posui");
        child.SetActive(false);
        
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
           // animator = child.gameObject.GetComponent<Animator>();
            print("pressed P");
            child.SetActive(true);
            gameObject.SetActive(false);
            animator.SetInteger("dead", 1);
        }
    }

}
