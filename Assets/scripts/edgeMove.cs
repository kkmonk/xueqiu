using UnityEngine;
using System.Collections;

public class edgeMove : MonoBehaviour {

    public Transform ball;
    private float stx;
	void Start () {
        stx = transform.position.x;
	}
	void Update () {
        transform.position = new Vector3(stx, ball.position.y+25f, ball.position.z+10f);
	}
}
