using UnityEngine;
using UnityEngine.Events;

public class DialogueTrigger : MonoBehaviour
{
    [SerializeField] protected int startNum;//строка с которой начать
    [SerializeField] protected int endOfThisDia;//до какого числа диалог
    public UnityEvent onTrigger;
    public virtual void StartDialogue()
    {
        transform.parent.GetComponent<DialogueSystem>().StartDialogue(startNum, endOfThisDia, onTrigger);
    }
}
