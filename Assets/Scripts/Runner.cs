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
    public float velY;

    // Use this for initialization
    void Start () {
        state = RunnerState.running;
        velY = GetComponent<Rigidbody>().velocity.y;
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
                 break;
            case State.jump:
                state = RunnerState.jumping;
                break;
            case State.duck:
                state = RunnerState.ducking;
                break;
        }

    }

}
