using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreRecoder : MonoBehaviour {

    public Text scoreText;
    public GameObject snowball;
    private Vector3 tmp, last;
    private float score;
    private int zhenshu;//每秒的帧数
    private int k;

	void Start () {
        score = 0;
        UpdateScore();
        tmp = snowball.transform.position;
        print(Time.deltaTime);
        zhenshu = (int)(1.0 / Time.deltaTime);
        k = 0;
    }
	
	void Update () {
        print("zhenshu");
        //按一定频率刷新
        k++;
        if (k>=zhenshu/2)
        {
            last = snowball.transform.position;
            addScore((last.z - tmp.z) * 35);
            UpdateScore();
            print("fenshu");
            k = 0;
        }

    }
    void FixedUpdate()
    {
    }
    void UpdateScore()
    {
        scoreText.text = "score:" + score;
    }
    void addScore(float value)
    {
        score += value;
    }
    float getValue()//分数生成函数
    {
        return 1.0f;
    }
}
