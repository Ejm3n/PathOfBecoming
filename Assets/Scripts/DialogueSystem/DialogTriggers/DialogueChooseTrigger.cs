using UnityEngine;

public class DialogueChooseTrigger : DialogueTrigger
{
    [SerializeField] int secondChoiceStart;//выбор2

    public override void StartDialogue()
    {
        transform.parent.GetComponent<DialogueSystem>().ChooseStart(startNum, secondChoiceStart, endOfThisDia, onTrigger);
    }
}
