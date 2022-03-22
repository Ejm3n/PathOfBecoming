using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayerControls;

public class HelpHandler : UncontrollableHandler
{
    public override void Interact()
    {
        if (ControlButtonsPress.HELP)
        {
            Interface.current.Hide_Tutor();
        }
        base.Interact();
    }
}
