using UnityEngine;
using System.Collections;
/*
 * 此脚本用来随机生成障碍物，需要考虑的地方有
 * 1.障碍物的密度
 * 2.障碍物的位置
 * 3.金币与障碍物的相对位置
 * 4.障碍物资源的回收 y
 */
public class RamdomCreateObstacal : MonoBehaviour
{

    public GameObject player;//小球
    //障碍物
    public GameObject fangzi;
    public GameObject dici;
    public GameObject snowMan;
    public GameObject gold;
    private float[] staticY = { 2f, 8.5f, 1.3f, 2.9f };//依次为地刺，雪人，小球,金币
    private float bx, bz;//障碍物出生的坐标
    private int gx, gz;//格子的坐标
    public float wid, len, front;
    private Vector3 tmp;//小球的当前位置
    private float startwait = 1f;
    private Queue recycle;//回收各种资源的垃圾桶，在达到一定数量的时候销毁
    private Queue goldRecycle;//回收金币的
    private bool[,] vis = new bool[100, 100];
    private float grid_len = 2.5f;
    private int obsType;
    private bool isGold = false;//是否生成金币
    private int dt;
    public int dis;
    private int fcret;
    private int temp_z;
    private int count = 0;
    private int obsnumber;
    private float angel;
    public Transform tr;
    int xLen, zLen;
    Vector3 stpot;
    /*
     * 销毁障碍物前要先判断该障碍物是否存在
     * target为一个gameObject
     * if(target!=null){
     *      Destroy(target);
     * }
     */
    void Start()
    {
        stpot = player.transform.position;
        angel = tr.localRotation.x;
        xLen = 34;
        zLen = 20;
        fcret = 1;
        dis = 100;
        temp_z = (int)(player.transform.position.z) - dis - 1;
        StartCoroutine(runObs());
        recycle = new Queue();
        goldRecycle = new Queue();
        //print((int)-12.5 % 5);
        isGold = true;
        dt = 1;
        obsnumber = 50;

    }
    void Update()
    {
        //垃圾站的数目大于60个时
        if (recycle.Count > 200)
        {
            
            while (recycle.Count >100 )
            {
                GameObject obs;
                obs = recycle.Dequeue() as GameObject;
                if (obs != null)
                    Destroy(obs);
            }
        }
        if (Time.time > dt)//每隔5秒生成一轮金币
        {
            isGold = !isGold;
            dt += 1;
        }
       // print("count=" + count);
    }
    IEnumerator runObs()
    {
        yield return new WaitForSeconds(startwait);//让代码等待startwait秒，再执行下面的代码
        /*生成障碍物的code*/
        while (true)
        {
            tmp = player.transform.position;
            if (tmp.z - temp_z < dis)
            {
                yield return new WaitForSeconds(startwait);
                continue;
            }
            if (obsnumber < 100) obsnumber += 5;
            temp_z += dis;
            clearMap();//先"清空"地图

            if (isGold)//是否需要生成金币
            {
                createGold();
				createGold ();
            }

            //随机生成15个障碍物
            for (int i = 0; i < obsnumber; i++)
            {
                /*
                 * 障碍物生成的位置必须在有效的位置上
                 * “有效的格子”指的是：
                 * 1.没有其他障碍物在格子上生成(vis[gx][gz]==false)
                 * 2.gx-25!=0 && gz!=0 
                 * 实际上,z是大于1的整数,|x|<25,x!=0
                 */
                gx = (int)getRandomNum() % xLen; 
                gz = (int)getRandomNum() % zLen;//生成区要狭长一点，
                obsType = getObsType();
                //如果格子无效，继续生成随机数
                while (vis[gx, gz]|| gz == 0)
                {
                    gx = (int)getRandomNum() % xLen;
                    gz = (int)getRandomNum() % zLen;
                }
                //生成了一个有效的位置，把对应的位置标记
                vis[gx, gz] = true;
                //print("(" + gx + "," + gz + ")");

                gx -= 17;
                if (gx > 0)
                    bx = rightGrid();
                else
                    bx = leftGrid();

                bz = upGrid();
                GameObject obs;
                obs = buildObs(obsType);
                recycle.Enqueue(obs);//新生成的对象入垃圾站
                yield return new WaitForSeconds(startwait / 100);
            }
            // Time.timeScale = 0;
            yield return new WaitForSeconds(startwait);
            if (fcret == 1)
            {
                temp_z -= dis;
                fcret = 0;
            }
        }

    }

    void clearMap()
    {
        for (int i = 0; i < 100; i++)
            for (int j = 0; j < 100; j++)
                vis[i, j] = false;
    }
    float getRandomNum()
    {
        return Random.Range(1f, 54f);
    }
    float rightGrid()//格子在原点的右侧
    {
        return (gx * 2 - 1) * grid_len;
    }
    float leftGrid()//格子在原点左侧
    {
        return(gx * 2 + 1) * grid_len;
    }
    float upGrid()//z方向的位置
    {
        if (fcret == 1) return tmp.z + (gz * 2 - 1) * grid_len;
        return tmp.z + dis + (gz * 2 - 1) * grid_len;
    }
    int getLineCount()
    {
        return (int)Random.Range(1f, 6f) % 3;
    }
    int getObsType()
    {
        return (int)Random.Range(1f, 6f) % 3;
    }
    /// <summary>
    /// 创建一个障碍物实例
    /// </summary>
    /// <param name="type">0-地刺，1-雪人，2-房子，3-金币</param>
    /// <returns></returns>
    GameObject buildObs(int type)//在此函数中判断类型并创建相应的障碍物
    {
        count++;
        switch (type)
        {
            case 0://dici
                return Instantiate(dici, new Vector3(bx, get_by(bz)+1, bz), Quaternion.identity) as GameObject;
            case 1://雪人
                return Instantiate(snowMan, new Vector3(bx, get_by(bz)+1, bz),Quaternion.AngleAxis(180,Vector3.up)) as GameObject;
            case 2://房子
			return Instantiate(fangzi, new Vector3(bx, get_by(bz)+1, bz), Quaternion.AngleAxis(180,Vector3.up)) as GameObject;
            case 3://金币
			return Instantiate(gold, new Vector3(bx, get_by(bz)-0.89f, bz), Quaternion.AngleAxis(90,Vector3.right)) as GameObject;
        }

        return null;
    }
    void createGold()
    {
        //随机生成1~3列金币
        GameObject obs;
        int lineCount = getLineCount() + 1;
        for (int r = 0; r < lineCount; r++)
        {
			gx = (int)getRandomNum() % (xLen/2);
            while (vis[gx, gz] == true)
            {
                gx = (int)getRandomNum() % xLen;
            }
            gz = 2;//从第二排格子开始
           // gx -= 13;
            if (gx > 0)
                bx = rightGrid();
            else
                bx = leftGrid();
            //每列生成4个金币
            for (int k = 0; k < 4; k++)
            {
                gz = 2 + k;
                vis[gx, gz] = true;
                bz = upGrid();
                obs = buildObs(3);
                goldRecycle.Enqueue(obs);//入金币回收站
            }

        }
    }
    float get_by(float bz)
    {
        return stpot.y-Mathf.Tan(17.0643f*Mathf.PI/180) * bz;
    }
}
