using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PlayerControls;
using System;
[Serializable]
public class Choices
{
    public string phrase;
    public DialogueTrigger dialogue;
}
public class ChoiceDialogueTrigger : DialogueTrigger
{
    public List<Choices> choices;
    int index = 0;
    public void IncreaseIndex(int ind)
    {
        if (ind < 0 && index == 0)
            index = choices.Count - 1;
        else if (ind > 0 && index == choices.Count - 1)
            index = 0;
        else
            index += ind;
        Interface.current.choicePanel.MoveIndicator(index);
    }
    public void ChoiceStart()
    {
        Engine.current.dialogueSystem.StartChooseDialogue(false);
        if(index != choices.Count-1)
        {
            choices[index].dialogue.StartDialogue();
            choices[index].dialogue.onTrigger.AddListener(this.StartDialogue);
        }
        else
        {
            choices[index].dialogue.StartDialogue();
            
        }
           
        choices.RemoveAt(index);
        
    }
    public override void StartDialogue()
    {
        if (choices.Count == 1)
        {
            choices[0].dialogue.StartDialogue();
            return;
        }
        Interface.current.choicePanel.DisablePanel();
        Interface.current.choicePanel.RewriteButtons(this);
        
        current = this;        
        
        Engine.current.playerController.Change_Controls<DIalogueHandler>();
        Engine.current.dialogueSystem.StartChooseDialogue(true);

    }
}

