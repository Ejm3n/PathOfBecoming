using UnityEngine;
using UnityEngine.Events;

public class DialogueTrigger : MonoBehaviour
{
    [SerializeField] protected int dialogueNumber;//строка с которой начать

    public UnityEvent onTrigger;
    public virtual void StartDialogue()
    {
        Engine.current.dialogueSystem.StartDialogue(dialogueNumber, onTrigger);
    }
}
