using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassingObjects : MonoBehaviour {

    public float speed;
    private Rigidbody rgb;
    private float frames;
    private bool die;

	// Use this for initialization
	void Start () {
        speed = -15f;
        rgb = GetComponent<Rigidbody>();
        frames = 5;
        die = false;
	}
	
	// Update is called once per frame
	void Update () {
        rgb.velocity = new Vector3(speed, rgb.velocity.y, rgb.velocity.z);
        //rgb.AddForce(speed, transform.position.x, transform.position.y);
        if (die)
        {
            frames -= 1;
            if (frames <= 0)
            {
                gameObject.SetActive(false);
                die = false;
            }
        }
    }

     void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("BackEdge"))
        {

            die = true;
        }
    }
}
