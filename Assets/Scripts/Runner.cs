using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum State
{
    run,
    jump,
    trip,
    die
}


public class Runner : MonoBehaviour {

    //private Rigidbody rgb;
    private RunnerState state;
    private Animator anim;
    public Vector3 startingPos;
    private Rigidbody rgb;
    private GameObject endCanvas;
    private Collider col;
    private bool dead = false;
    private AudioSource fall;


    // Use this for initialization
    void Start()
    {
        endCanvas = Resources.Load<GameObject>("Prefabs/EndCanvas");
        fall = GetComponent<AudioSource>();
        rgb = GetComponent<Rigidbody>();
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
                break;
            case State.trip:
                rgb.velocity = new Vector3(0, rgb.velocity.y, 0);
                state = RunnerState.tripping;
                anim.SetInteger("action", 2);
                fall.Play();
                break;
            case State.die:
                state = RunnerState.dying;
                anim.SetInteger("action", 3);
                break;
        }

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Obstacle"))
        {
            if (state != RunnerState.tripping && state != RunnerState.dying)
            {
                ChangeState(State.trip);
            }
        }
        else if (other.gameObject.layer == LayerMask.NameToLayer("BackEdge"))
        {
            if (!dead)
            {
                rgb.velocity = new Vector3(0, 0, 0);
                rgb.position = new Vector3(transform.position.x + .75f, transform.position.y, transform.position.z);
                ChangeState(State.die);
                Instantiate(endCanvas);
                endCanvas.SetActive(true);
                dead = true;
            }
        }
    }

}
