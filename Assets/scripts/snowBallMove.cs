using UnityEngine;
using System.Collections;

public class snowBallMove : MonoBehaviour {

    private Rigidbody rg;
    private float foc=8;
    private Vector3 zhongli;
    private float u;//重力感应的权重
    float force=0.7f;
    ConstantForce cf;
    int cnt,sum=0;
	void Start () {

        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        rg = GetComponent<Rigidbody>();
        u = 40;
        cf = GetComponent<ConstantForce>();
        cf.force = new Vector3(0f, -force, force / Mathf.Tan(17.0643f * Mathf.PI / 180));
        cnt = (int)(1.0f / Time.deltaTime);
           
    }
    
	void Update () {
        sum++;
        if(sum>cnt*10)//每10秒增加一次速度
        {
            force += 0.3f;
            cf.force= new Vector3(0f, -force, force / Mathf.Tan(17.0643f * Mathf.PI / 180));
            sum = 0;
			print ("speed up");
        }
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        //rg.AddForce(new Vector3(0, 0, foc));
        if (Input.GetKey(KeyCode.A))
        {
            rg.AddForce(new Vector3(-foc, 0, 0));
        }
        if(Input.GetKey(KeyCode.D))
        {
            rg.AddForce(new Vector3(foc, 0, 0));
        }
        if (Input.GetKey(KeyCode.W))
        {
            rg.AddForce(new Vector3(0, 0, foc));
        }
        if (Input.GetKey(KeyCode.S))
        {
            rg.AddForce(new Vector3(0, 0, -foc));
        }

        zhongli = Input.acceleration;//获取重力感应
        rg.AddForce(new Vector3(zhongli.x * u, 0f, 0f));//根据重力来加速 
        
        // rg.AddForce(new Vector3(0f, -force, force / Mathf.Tan(17.0643f * Mathf.PI / 180)));//施加向前的力

        //if (Input.touchCount!=0)
        //{
        //    Touch touch = Input.GetTouch(0);
        //    Vector3 start=Vector3.zero, end;
        //    float touchX, touchZ;
        //    if (touch.phase == TouchPhase.Began)
        //    {
        //        start = touch.position;
        //    }
        //    if(touch.phase==TouchPhase.Ended)
        //    {
        //        end = touch.position;
        //        touchX = end.x - start.x;
        //        //向左移动
        //        if (touchX < -20)
        //        {
        //            transform.Translate(new Vector3(-10f, 0f, 0f));
        //            //print("zuoyi");
        //            Debug.Log("zuoyi");
        //        }
        //        //向右移动
        //        else if (touchX > 20)
        //        {
        //            transform.Translate(new Vector3(10f, 0f, 0f));
        //            //print("youyi");
        //            Debug.Log("youyi");
        //        }
        //    }
        //}


    }
}
