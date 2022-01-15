using UnityEngine;

public class PlaceForHassle : PlaceForItem
{
    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        current = this;
        Interface.current.eyeOfHassle.alpha = 1;
    }

    protected override void OnTriggerExit2D(Collider2D collision)
    {
        current = this;
        Interface.current.eyeOfHassle.alpha = 0;
    }
}
