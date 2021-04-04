using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CageOpen : MonoBehaviour
{
    private Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
       if(PazzleControl.youWin)
            anim.SetBool("open", true);
    }
}
