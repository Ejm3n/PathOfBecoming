using UnityEngine;

public class PlaceForHassle : PlaceForItem
{
    public override void Start_Event()
    {
        if (Engine.current.eyeOfHassle && Engine.current.eyeOfHassle.eyeAwaken)
            base.Start_Event();
        else if (Interface.current.inventory.chosenItem)
            Cannot_Interact();
        else
            Examine();
    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if (Engine.current.eyeOfHassle && Engine.current.eyeOfHassle.eyeAwaken)
        {
            current = this;
            Interface.current.eyeOfHassle.alpha = 1;
        }
        else
        {
            base.OnTriggerEnter2D(collision);
        }
    }

    protected override void OnTriggerExit2D(Collider2D collision)
    {
        if (Engine.current.eyeOfHassle && Engine.current.eyeOfHassle.eyeAwaken)
        {
            current = null;
            Interface.current.eyeOfHassle.alpha = 0;
        }
        else
        {
            base.OnTriggerExit2D(collision);
        }
    }
}
