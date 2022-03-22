
using UnityEngine.Events;

public class DialogueTriggerPreAction : DialogueTrigger
{
    public UnityEvent dialogueStart;

    public override void StartDialogue()
    {
        dialogueStart?.Invoke();
        base.StartDialogue();
    }
}
