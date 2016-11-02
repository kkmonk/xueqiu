using UnityEngine;
using System.Collections;

public class planeCount : MonoBehaviour {

    public static int count;
	void Start () {
        count = 0;
	}
    void OnTriggerExit(Collider other)
    {
        if (other.name.Equals("snowBall"))
        {
            count++;
            print("exit this plane");
        }
    }
    public int getCount()
    {
        return count;
    }

}
