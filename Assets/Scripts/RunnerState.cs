﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RunnerState
{
    public static RunningState running = new RunningState();
    public static JumpingState jumping = new JumpingState();
    public static TripState tripping = new TripState();
    public static DeathState dying = new DeathState();

    public virtual void handleInput(Runner runner) { }
    public virtual void update(Runner runner) { }

};

public class RunningState : RunnerState
{
    private float floatSpeed = 10f;
    private Rigidbody rgb;

    public override void handleInput(Runner runner)
    {
        rgb = runner.GetComponent<Rigidbody>();
        float inX = Input.GetAxis("Horizontal");
        float inZ = Input.GetAxis("Z");
        bool inY = Input.GetKeyDown("space");
        rgb.velocity = new Vector3(floatSpeed * inX, rgb.velocity.y, floatSpeed * inZ);
        if (inY)
        {
            rgb.AddForce(new Vector3(0, 350f, 0));
            runner.ChangeState(State.jump);
        }
    }


    public override void update(Runner runner)
    {

    }



}

public class JumpingState : RunnerState
{
    private float floatSpeed = 5f;
    private Rigidbody rgb;
    private float timeTillJump = 1.5f;
    private float timer = 1.5f;


    public override void handleInput(Runner runner)
    {
        rgb = runner.GetComponent<Rigidbody>();
        float inX = Input.GetAxis("Horizontal");
        float inZ = Input.GetAxis("Z");
        rgb.velocity = new Vector3(floatSpeed * inX, rgb.velocity.y, floatSpeed * inZ);
    }


    public override void update(Runner runner)
    {
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            timer = timeTillJump;
            runner.ChangeState(State.run);
        }
    }



}

public class TripState : RunnerState
{
    private float timeDown = 1f;
    private float timer = 1f;
    private float speed = -8f;
    private Rigidbody rgb;

    public override void handleInput(Runner runner)
    {

    }


    public override void update(Runner runner)
    {
        rgb = runner.GetComponent<Rigidbody>();
        rgb.velocity = new Vector3(speed, rgb.velocity.y, 0);

        timer -= Time.deltaTime;
        if (timer < 0)
        {
            timer = timeDown;
            runner.ChangeState(State.run);
        }
    }

}

public class DeathState : RunnerState
{

    //DO NOTHING IN DEATH STATE
    public override void handleInput(Runner runner)
    {
    }


    public override void update(Runner runner)
    {
    }

}
