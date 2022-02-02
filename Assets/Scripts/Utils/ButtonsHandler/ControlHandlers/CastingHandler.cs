using PlayerControls;

public class CastingHandler : UncontrollableHandler
{
    public override void Down()
    {
        if(ControlButtonsPress.DOWN)
            Interface.current.spellBook.Change_Cast_Angle(ControlButtonsAxis.yAxisRaw);
    }

    public override void Interact()
    {
        base.Interact();
    }

    public override void Up()
    {
        if (ControlButtonsPress.UP)
            Interface.current.spellBook.Change_Cast_Angle(ControlButtonsAxis.yAxisRaw);
    }

    public override void Use_Spell()
    {
        if (!ControlButtonsHold.USESPELL)
            Interface.current.spellBook.Cast();
    }
}
