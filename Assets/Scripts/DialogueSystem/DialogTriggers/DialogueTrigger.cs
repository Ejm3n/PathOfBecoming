using UnityEngine;
using UnityEngine.Events;

public class DialogueTrigger : MonoBehaviour
{
    [SerializeField] protected int dialogueNumber;//строка с которой начать
    public static DialogueTrigger current;
    public UnityEvent onTrigger;
    public virtual void StartDialogue()
    {
        current = this;
        Engine.current.dialogueSystem.StartDialogue(dialogueNumber, onTrigger);
    }
}
