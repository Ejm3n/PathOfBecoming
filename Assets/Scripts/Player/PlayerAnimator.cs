using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{

    private Animator anim;
    private float walk;
    private PlayerController PC;

    AudioClip step;
    
    void Start()
    {
        PC = transform.parent.GetComponent<PlayerController>();
        anim = GetComponent<Animator>();
        step = Resources.Load<AudioClip>("Sounds/Effects/Звук/Footsteps/footstep forest 2");
    }

    public void Step()
    {
        SoundRecorder.Play_Effect(step);
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
