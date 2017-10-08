using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum State
{
    run,
    jump,
    duck
}


public class Runner : MonoBehaviour {

    //private Rigidbody rgb;
    private RunnerState state;
    private Animator anim;
    public int action;
    public Vector3 startingPos;


    // Use this for initialization
    void Start()
    {
        state = RunnerState.running;
        anim = GetComponent<Animator>();
        startingPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
    }

	
	// Update is called once per frame
	void Update () {
        state.handleInput(this);
        state.update(this);
	}

    public void ChangeState(State newState)
    {
        switch(newState)
        {
            case State.run:
                state = RunnerState.running;
                anim.SetInteger("action", 0);
                break;
            case State.jump:
                state = RunnerState.jumping;
                anim.SetInteger("action", 1);
                action = 2;
                break;
            case State.duck:
                state = RunnerState.ducking;
                break;
        }

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Death"))
        {
            transform.position = startingPos;
        }
        else if (other.gameObject.layer == LayerMask.NameToLayer("BackEdge"))
        {
            transform.position = startingPos;
        }
    }

}
