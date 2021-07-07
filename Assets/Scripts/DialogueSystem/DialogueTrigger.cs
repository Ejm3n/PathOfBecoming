using UnityEngine;
using UnityEngine.Events;

public class DialogueTrigger : MonoBehaviour
{
    [SerializeField] protected int startNum;//строка с которой начать
    [SerializeField] protected int endOfThisDia;//до какого числа диалог
    [SerializeField] protected UnityEvent onTrigger;

    private void OnTriggerEnter2D(Collider2D collision)//проверяем кто зашел, стартуем диалог
    {
        transform.parent.GetComponent<DialogueSystem>().StartDialogue(startNum, endOfThisDia, onTrigger);
        Destroy(gameObject);
    }
}
