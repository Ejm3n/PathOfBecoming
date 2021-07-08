using UnityEngine.Events;
using UnityEngine;

public class CheckpointDialogue : DialogueTrigger
{
    public UnityEvent onCheckpoint;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        DialogueSystem ds = transform.parent.GetComponent<DialogueSystem>();
        onTrigger.AddListener(() => ds.Checkpoint(this));
        ds.StartDialogue(startNum, endOfThisDia, onTrigger);
        Destroy(gameObject);
    }
}
