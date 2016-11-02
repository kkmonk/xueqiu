using UnityEngine;
using System.Collections;

public class scaleTEST : MonoBehaviour {
	//inspector中是 5,0.01,10
	private float x,y,z;

	void Start () {
		x = transform.localScale.x;
		y = transform.localScale.y;
		z = transform.localScale.z;

	}

}
