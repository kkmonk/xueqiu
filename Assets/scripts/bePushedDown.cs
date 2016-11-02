using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax;//只需要限制x的距离就可以了
}

public class bePushedDown : MonoBehaviour {
    public Boundary bnd;
    private Rigidbody rg;

    void Start()
    {
        rg = GetComponent<Rigidbody>();
    }

    void Update()
    {
        //限制雪球的位置
        rg.position = new Vector3(Mathf.Clamp(rg.position.x, bnd.xMin, bnd.xMax), rg.position.y, rg.position.z); 
    }
}
