using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlatPlayerMovement : MonoBehaviour {

    private Rigidbody rgb;
    public float floatSpeed = 5f;
    private float speed = 20f;
    private 

    // Use this for initialization
    void Start () {
        rgb = GetComponent<Rigidbody>();
		
	}

	
	// Update is called once per frame
	void Update () {
        //use get button down for attacks uses axis name
        float inX = Input.GetAxis("Horizontal");
        float inZ = Input.GetAxis("Z");
        float inY = Input.GetAxis("Jump");
        rgb.velocity = new Vector3(floatSpeed * inX, rgb.velocity.y, floatSpeed * inZ);
        if (transform.position.y <= -3.19)
        {
            rgb.AddForce(new Vector3(0, inY * 300f, 0));
        }
    }


}
