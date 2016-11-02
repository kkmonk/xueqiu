using UnityEngine;
using System.Collections;

/*
 *  按时销毁物体
 *  2016/8/31--弃用
 */
 
public class DestroyByTime : MonoBehaviour {

    public float lifeTime;
    public GameObject player;
    //障碍物和金币
    public GameObject fangzi;
    public GameObject dici;
    public GameObject snowMan;
    public GameObject gold;

    void Start () {
        //need a test;
        if(fangzi!=null)
            Destroy(fangzi, lifeTime);
        if (dici != null)
            Destroy(dici,lifeTime);
        if(snowMan!=null)
            Destroy(snowMan, lifeTime);
        if(gold!=null)
            Destroy(gold, lifeTime);
	    
	}
	void Update () {
	
	}
}
