using PlayerControls;

public class DefaultHandler : ControlHandler
{
    public override void Down()
    {
        return;
    }

    public override void Interact()
    {
        //interaction with objects
    }

    public override void Inventory_Button()
    {
        //show inventory
    }

    public override void Left()
    {
        Engine.current.playerController.Move(ControlButtonsAxis.xAxisRaw);
    }

    public override void Right()
    {
        Engine.current.playerController.Move(ControlButtonsAxis.xAxisRaw);
    }

    public override void Switch_Spell()
    {
        //switch spell
    }

    public override void Up()
    {
        Engine.current.playerController.Jump();
    }

    public override void Use_Spell()
    {
        //cast spell
    }
}
