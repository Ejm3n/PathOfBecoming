using PlayerControls;

public class CastingHandler : ControlHandler
{
    public override void Down()
    {
        return;
    }

    public override void Interact()
    {
        return;
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
        if (!ControlButtonsHold.USESPELL)
            Interface.current.spellBook.Cast();
    }
}
