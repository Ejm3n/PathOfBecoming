using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{

    private Animator anim;
    private float walk;
    [SerializeField]
    private PlayerController PC;
    
    void Start()
    {
        anim = GetComponent<Animator>(); 
    }

    
    void Update()
    {
        walk = PC.MoveInput;
        if(walk != 0)
        {
            anim.SetBool("walk", true);
        }
        else
        {
            anim.SetBool("walk", false);
            SoundManager.instance.Steps();
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
