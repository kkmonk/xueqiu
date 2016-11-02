using UnityEngine;
using System.Collections;

public class followSB : MonoBehaviour {
    public Transform snball;
	// Update is called once per frame
	void Update () {
        transform.position = snball.position;
	}
}
