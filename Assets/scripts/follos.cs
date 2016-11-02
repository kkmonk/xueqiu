using UnityEngine;
using System.Collections;

/*摄像机跟随脚本*/

public class follos : MonoBehaviour {
    
    public Transform tf;//小球的位置
    private Vector3 offset;//偏移量
    private Vector3 ballRadis;//小球的半径
    
    void Start () {
        offset = transform.position - tf.position;
	}
	
	void Update () {
        ballRadis = tf.localScale;
        transform.position = getOffset()+tf.position;
        
	}
    Vector3 getOffset()
    {
        Vector3 va;
        va = offset * (ballRadis.x / 2 + 1);
        return va;
    }

}
