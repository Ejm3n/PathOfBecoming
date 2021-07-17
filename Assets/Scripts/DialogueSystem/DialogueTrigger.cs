using UnityEngine;
using UnityEngine.Events;

public class DialogueTrigger : MonoBehaviour
{
    [SerializeField] protected int startNum;//строка с которой начать
    [SerializeField] protected int endOfThisDia;//до какого числа диалог
    public UnityEvent onTrigger;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        StartDialogue();
    }
    protected void StartDialogue()
    {
        Debug.Log("start" + startNum + " end " + endOfThisDia);
        transform.parent.GetComponent<DialogueSystem>().StartDialogue(startNum, endOfThisDia, onTrigger);
        Destroy(gameObject);
    }
}
