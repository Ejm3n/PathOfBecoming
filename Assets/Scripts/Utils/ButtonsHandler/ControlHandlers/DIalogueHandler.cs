using PlayerControls;

public class DIalogueHandler : ControlHandler
{
    public override void Down()
    {
        return;
    }

    public override void Interact()
    {
        if (!ControlButtonsPress.INTERACT)
        {
            return;
        }

        if (DialogueTrigger.current is ChoiceDialogueTrigger)
        {
            ChoiceDialogueTrigger cdt = (ChoiceDialogueTrigger)DialogueTrigger.current;
            cdt.ChoiceStart();
        }
        else
        {
            Engine.current.dialogueSystem.Next();
        }
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
        if (!(ControlButtonsPress.DOWN || ControlButtonsPress.UP))
            return;

        if (DialogueTrigger.current is ChoiceDialogueTrigger)
        {
            ChoiceDialogueTrigger cdt = (ChoiceDialogueTrigger)DialogueTrigger.current;
            cdt.IncreaseIndex(ControlButtonsAxis.yAxisRaw*-1);
        }
    }

    public override void Use_Spell()
    {
        return;
    }
}
