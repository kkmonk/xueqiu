using UnityEngine;
using System.Collections;
/*
 * 小球变大的脚本
 */
public class RadisAdd : MonoBehaviour {

    private Vector3 st;
    private Vector3 temp;
    private float dis;
    private float maxR;
    private float dlta;
    void Start () {
        st = gameObject.transform.position;
        dis = 100f;
        maxR = 13.3f;
        dlta = 0.07f;
	}
	void Update () {
        temp = gameObject.transform.position;
        if(temp.z-st.z>dis)
        {
            if (gameObject.transform.localScale.x < maxR)//球的最大半径不能超过maxR
            {
                gameObject.transform.localScale += new Vector3(dlta,dlta,dlta);
            }
            dis += 80;
        }
	}
}
