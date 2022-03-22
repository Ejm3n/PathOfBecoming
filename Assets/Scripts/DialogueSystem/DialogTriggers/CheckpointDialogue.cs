using UnityEngine.Events;

public class CheckpointDialogue : DialogueTrigger
{
    public UnityEvent onCheckpoint;

    public override void StartDialogue()
    {
        DialogueSystem ds = Engine.current.dialogueSystem;
        UnityEvent _event = new UnityEvent();
        _event.AddListener(() => ds.Checkpoint(this));
        ds.StartDialogue(dialogueNumber, _event);
    }
}
