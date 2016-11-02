using UnityEngine;
using System.Collections;

public class ces : MonoBehaviour {

    void OnTriggerEnter(Collider other)
    {
        if (other.name.Equals("snowBall"))
        {
            print("exit this plane");
        }
    }
}
