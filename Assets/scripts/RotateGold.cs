using UnityEngine;
using System.Collections;

/*金币旋转脚本*/
public class rotateGold : MonoBehaviour {

	void Start () {
	   
	}
	void Update () {
        transform.Rotate(Vector3.forward, 60f * Time.deltaTime);//绕Y轴旋转，角速度为30
    }
    
}
