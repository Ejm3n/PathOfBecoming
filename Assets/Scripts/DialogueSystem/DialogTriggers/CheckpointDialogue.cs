using UnityEngine.Events;

public class CheckpointDialogue : DialogueTrigger
{
    public UnityEvent onCheckpoint;

    public override void StartDialogue()
    {
        DialogueSystem ds = Engine.current.dialogueSystem;
        onTrigger.AddListener(() => ds.Checkpoint(this));
        ds.StartDialogue(dialogueNumber, onTrigger);
    }
}
