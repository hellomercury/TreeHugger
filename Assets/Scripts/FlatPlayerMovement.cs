using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlatPlayerMovement : MonoBehaviour {

    private Rigidbody rgb;
    public float floatSpeed = 5f;
    private Vector3 depthMove = new Vector3(0, Mathf.Sin(Mathf.PI / 6), Mathf.Cos(Mathf.PI / 6));
    private Vector3 horizontalMove = new Vector3(1,0,0);
    private Vector3 jumpMove = new Vector3(0, 1, 0);
    private float speed = 20f;

    // Use this for initialization
    void Start () {
        rgb = GetComponent<Rigidbody>();
		
	}
	
	// Update is called once per frame
	void Update () {
        float inX = Input.GetAxis("Horizontal");
        float inZ = Input.GetAxis("Z");
        float inY = Input.GetAxis("Jump");
        rgb.velocity = new Vector3(floatSpeed * inX, 0, floatSpeed * inZ);
        rgb.AddForce(new Vector3(0, inY * 200f, 0));
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Edge"))
        {
            rgb.angularVelocity = Vector3.zero;

        }
    }
}
