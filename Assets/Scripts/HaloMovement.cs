using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HaloMovement : MonoBehaviour {

	// Use this for initialization
	void Start () {
        transform.position = new Vector3(transform.parent.position.x -0.15f, 0.25f, transform.parent.position.z - 1.15f);
    }

    void Update()
    {
        transform.position = new Vector3(transform.parent.position.x -0.15f, 0.25f, transform.parent.position.z - 1.15f);
    }
	
}
