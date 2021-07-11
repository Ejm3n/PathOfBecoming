using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{

    private Animator anim;
    private float walk;
    private PlayerController PC;
    
    void Start()
    {
        PC = transform.parent.GetComponent<PlayerController>();
        anim = GetComponent<Animator>(); 
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
