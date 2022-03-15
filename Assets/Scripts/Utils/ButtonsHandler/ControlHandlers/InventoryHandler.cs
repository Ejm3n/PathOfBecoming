using PlayerControls;
using UnityEngine;

public class InventoryHandler : UncontrollableHandler
{
    public override void Interact()
    {
        base.Interact();
        if (InteractEvent.current && ControlButtonsPress.INTERACT)
        {
            InteractEvent.current.Start_Event();
            Interface.current.inventory.Close_Inventory();
        }
    }

    public override void Inventory_Button()
    {
        if (ControlButtonsPress.DOWN)
            Interface.current.inventory.Close_Inventory();
    }

    public override void Left()
    {
        if (ControlButtonsPress.LEFT ^ ControlButtonsPress.RIGHT)
            Interface.current.inventory.Scroll_Inventory(ControlButtonsAxis.xAxisRaw);
    }

    public override void Right()
    {
        return;
    }
}
