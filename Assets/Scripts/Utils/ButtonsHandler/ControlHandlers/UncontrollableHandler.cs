using UnityEngine;

public class UncontrollableHandler : ControlHandler
{
    public override void Down()
    {
        return;
    }

    public override void Interact()
    {
        if (Engine.current.playerController.isGround)
            Engine.current.playerController.rb.velocity = Vector3.zero;
    }

    public override void Inventory_Button()
    {
        return;
    }

    public override void Left()
    {
        return;
    }

    public override void Right()
    {
        return;
    }

    public override void Switch_Spell()
    {
        return;
    }

    public override void Up()
    {
        return;
    }

    public override void Use_Spell()
    {
        return;
    }
}
