using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    [SerializeField] int startNum;//строка с которой начать
    [SerializeField] int endOfThisDia;//до какого числа диалог
    [SerializeField] GameObject moveButtons;
    [SerializeField] GameObject nextTriggerToActivate;//какой триггер включить следующим
    [SerializeField] GameObject[] triggersToDelete;//какие триггеры удалить
   // public static Action<bool> DialogStarted;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerController>() != null)
        {
            var ds = FindObjectOfType<DialogueSystem>();
            ds.StartDialogue(startNum, endOfThisDia,nextTriggerToActivate);                      
            for (int k = 0; k < triggersToDelete.Length; k++)
            {
                if (triggersToDelete[k] != null)
                {
                    Destroy(triggersToDelete[k]);
                }
            }
            Destroy(gameObject);
        }
    }
}
