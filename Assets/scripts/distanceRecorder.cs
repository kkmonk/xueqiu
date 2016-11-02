using UnityEngine;
using System.Collections;
/*距离记录脚本*/
public class distanceRecorder : MonoBehaviour {
	public GameObject ball;
	private float rollingDistance;//记录球的滚动距离
	private float radiesIncres;//半径增加的幅度
	private Vector3 startPos;//小球开始所处的位置
	private Vector3 temp;//小球当前的位置
	private bool isGamePused=true;//游戏暂停

	void Start () {
		rollingDistance = 0f;
		startPos = ball.transform.position;
		radiesIncres = 0f;
	}

	void Update () {
		temp = ball.transform.position;
		//在斜面上的计算方法需要有所不同
		rollingDistance = Mathf.Abs(temp.x - startPos.x) ;
		//滚动的距离超过了100个单位
		if (rollingDistance > 100f) {
			startPos = temp;
			//增大小球的半径
			ball.transform.localScale += new Vector3 (radiesIncres, radiesIncres, radiesIncres);
		}
		//暂停
		if (Input.GetKeyDown (KeyCode.G)) {
			if (isGamePused) {
				Time.timeScale = 0;
			} else {
				Time.timeScale = 1;
			}
			isGamePused = !isGamePused;

		}
	}
}
