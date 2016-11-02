using UnityEngine;
using System.Collections;
/*小球移动脚本*/
public class move : MonoBehaviour {
    public float speed;
    private Vector3 pos;
    private Rigidbody rg;

	void Start () {
        //speed = 40f;
        rg = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {
        pos = transform.position;
        if(!(pos.y>80))
        {
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            {
                //pos.x -= speed * Time.deltaTime;
                //transform.position = pos;
                rg.AddForce(new Vector3(-10f, 0, 0));
                print("press w");

            }
            if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            {
                //pos.x += speed * Time.deltaTime;
                //transform.position = pos;
                rg.AddForce(new Vector3(10f, 0, 0));
            }
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                //pos.z -= speed * Time.deltaTime;
                //transform.position = pos;
                rg.AddForce(new Vector3(0, 0, -10f));
            }
            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                //pos.z += speed * Time.deltaTime;
                //transform.position = pos;
                rg.AddForce(new Vector3(0, 0, 10f));
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                pos.y += speed * Time.deltaTime*3;
                transform.position = pos;
            }

        }
	    
    }
    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.name=="Cube")
        GameObject.Destroy(other.gameObject);
        
    }
}
