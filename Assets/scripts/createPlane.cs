using UnityEngine;
using System.Collections;
//小球滚到某个位置，生成地形
public class createPlane : MonoBehaviour {

	public GameObject plane;
	private float passedTime;
	private int i = 1;
	private Vector3 pos;
	public GameObject first;
	private Vector3 adds=new Vector3 (0f, 0f, 5f);

	// Use this for initialization
	void Start () {
		passedTime = 0;
		pos = first.transform.position + adds;
	}
	
	// Update is called once per frame
	void Update () {
		passedTime = Time.time;
		if(passedTime>10*i){
			i++;
			Instantiate (plane, pos,Quaternion.identity);
			pos += adds;
		}
	}
}
