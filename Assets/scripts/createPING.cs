using UnityEngine;
using System.Collections;

public class createPING : MonoBehaviour
{

    /*
	 * 1.在斜面后生成一个平面，此时斜面为参考面，平面为生成面
	 * 而后，平面和生成面互换，交替循环
	 * 2.考虑使用过队列
	 * 
	*/
    public GameObject cankao;//参考面，球体所在的位置，根据这个位置生成下一个plane
    public GameObject shengcheng;//生成面
    private float len_cankao, len_shengcheng;//x方向为宽--wid，z方向为长--len
    private float staticX;//x方向的坐标不参与任何运算
    private float angR, angD;//斜的平面绕x轴的旋转角度，一个是角度，一个是弧度
    private int flag;//1--生成的是平面,0--生成的是斜面
                     //private float[] k={18f,28f,38f,48f,58f,28f,30f};
    private Queue rec;
    int cnt = 0;
    void Start()
    {
        rec = new Queue();
        flag = 1;
        staticX = cankao.transform.position.x;
        angD = cankao.transform.localRotation.eulerAngles.x;
        angR = Mathf.PI / 180 * angD;//计算弧度
        createTerrain(40);
        
    }
    void Update()
    {
        if(planeCount.count>15)//清除多余的平面
        {
            int s = 0;
            while(rec.Count>0)
            {
                s++;
                if (s > 20)
                { break; }
                GameObject obs = rec.Dequeue() as GameObject;
                if (obs != null)
                {
                    Destroy(obs);
                }

            }
            print("当前平面的个数"+ planeCount.count);
            planeCount.count -= 15;
            print("减了以后平面的个数" + planeCount.count);
            createTerrain(40);//生成新的平面


        }
    }
    //定位平面的中心点
    Vector3 locateCenter()
    {

        Vector3 poc;
        if (flag == 1)
        {
            //由斜面生成平面
            poc = new Vector3(staticX, downY(angR, len_cankao / 2), downZ(angR, len_cankao / 2) + len_shengcheng / 2);

        }
        else
        {
            /*由平面生成斜面,此时生成是斜面*/
            poc = new Vector3(staticX, downY(angR, len_shengcheng / 2), downZ(angR, len_cankao / 2, len_shengcheng / 2));

        }
        return poc;

    }
    //计算Y,Z方向的坐标
    //angle总是平面与x轴形成的角度
    float downY(float angle, float dis)
    {

        float y0 = cankao.transform.position.y;
        //angle = Mathf.PI / 180 * angle;//sin在计算的时候用的是弧度，所以要先把角度转换成弧度
        float res = 0;
        res = y0 - Mathf.Abs(dis * Mathf.Sin(angle));
        return res;

    }
    float downZ(float angle, float dis)
    {

        float z0 = cankao.transform.position.z;
        float res = 0;
        //angle = Mathf.PI / 180 * angle;
        res = z0 + Mathf.Abs(dis * Mathf.Cos(angle));
        return res;

    }
    //由平面生成斜面时
    float downZ(float angle, float disPing, float disXie)
    {

        float res = 0;
        float z0 = cankao.transform.position.z;
        //angle = Mathf.PI / 180 * angle;
        res = z0 + disPing + Mathf.Abs(disXie * Mathf.Cos(angle));
        return res;

    }
    void change()
    {

        GameObject tmp = shengcheng;
        shengcheng = cankao;
        cankao = tmp;

    }


    void createTerrain(int n)
    {
        for (int i = 0; i < n; i++)
        {
            len_cankao = cankao.transform.lossyScale.z;
            len_shengcheng = shengcheng.transform.lossyScale.z;

            GameObject tmp = cankao;
            if (flag == 1)
            {
                cankao = Instantiate(shengcheng, locateCenter(), Quaternion.identity) as GameObject;//生成一个新的plane
                flag = 0;
            }
            else
            {
                cankao = Instantiate(shengcheng, locateCenter(), Quaternion.Euler(angD, 0, 0)) as GameObject;//生成一个新的plane
                flag = 1;
            }
            shengcheng = tmp;
            rec.Enqueue(cankao);
            cnt++;
            //print("生成平面的个数是：" + cnt);

        }


    }
}

