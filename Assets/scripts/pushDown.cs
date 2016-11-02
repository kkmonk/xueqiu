using UnityEngine;
using System.Collections;

public class pushDown : MonoBehaviour {

    void OnCollisionEnter(Collision other)
    {
        if(string.Equals(other.gameObject.name, "snowBall") )
        {
            other.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0f, -120f, 0f));
            print("压力发生");
        }     
    }
    void OnCollisionExit(Collision other)
    {
        if (string.Equals(other.gameObject.name, "snowBall"))
        {
            other.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0f, -120f, 0f));
            print("压力发生");
        }
    }
    void OnCollisionStay(Collision other)
    {
        if (string.Equals(other.gameObject.name, "snowBall"))
        {
            other.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0f, -120f, 0f));
            print("压力发生");
        }
    }
}
