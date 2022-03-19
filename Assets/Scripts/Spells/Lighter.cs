using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lighter : Spell
{
    public override void Cast(Vector3 firePoint, float angle)
    {
        base.Cast(firePoint, angle);
        //animation
        Engine.current.playerController.animator.SetTrigger("CastingLight");
    }
}
