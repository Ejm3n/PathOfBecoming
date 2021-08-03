﻿using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private Animator anim;
    private float walk;
    private PlayerController PC;

    AudioClip[] steps;
    AudioClip jump;

    void Start()
    {
        PC = transform.parent.GetComponent<PlayerController>();
        anim = GetComponent<Animator>();
        steps = Resources.LoadAll<AudioClip>("Sounds/Effects/Footsteps/Forest");
        jump = Resources.Load<AudioClip>("Sounds/Effects/Footsteps/jump");
    }

    public void Step()
    {
        SoundRecorder.Play_Effect(steps[Random.Range(0, steps.Length)]);
    }

    public void Jump()
    {
        SoundRecorder.Play_Effect(jump);
    }

    void Update()
    {
        walk = Joystick.axisX;
        if(walk != 0)
        {
            anim.SetBool("walk", true);
        }
        else
        {
            anim.SetBool("walk", false);
        }

        if (!PC.isGround)
        {
            anim.SetBool("jump", true);
        }
        else
        {
            anim.SetBool("jump", false);
        }
    }
}
