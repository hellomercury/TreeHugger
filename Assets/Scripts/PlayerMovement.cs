using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    private Rigidbody rgb;
    public float floatSpeed = 5f;
    private float zmove = 2f;
    private Vector3 depthMove = new Vector3(0, Mathf.Sin(Mathf.PI / 6), Mathf.Cos(Mathf.PI / 6));
    private Vector3 horizontalMove = new Vector3(1,0,0);
    private Vector3 jumpMove = new Vector3(0, 1, 0);
    private float speed = 4f;

    // Use this for initialization
    void Start () {
        rgb = GetComponent<Rigidbody>();
		
	}
	
	// Update is called once per frame
	void Update () {
        float inX = Input.GetAxis("Horizontal");
        float inZ = Input.GetAxis("Z");
        float inY = Input.GetAxis("Jump");
        rgb.AddForce(speed * (inX * horizontalMove));
        rgb.AddForce(speed * (inZ * depthMove));
        rgb.AddForce(speed * (inY * jumpMove));
    }
}
