using PlayerControls;
using UnityEngine;

public class DIalogueHandler : UncontrollableHandler
{
    public override void Interact()
    {
        base.Interact();

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
}
