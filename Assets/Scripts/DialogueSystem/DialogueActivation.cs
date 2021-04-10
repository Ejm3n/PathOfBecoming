using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueActivation : MonoBehaviour
{
    [SerializeField] int startNum;//строка с которой начать
    [SerializeField] int endOfThisDia;//до какого числа диалог
    [SerializeField] GameObject nextTriggerToActivate;//какой триггер включить следующим                                                     // public static Action<bool> DialogStarted;
    [SerializeField] DialogueSystem ds;
    private void OnEnable()
    {
            ds.StartDialogue(startNum, endOfThisDia, nextTriggerToActivate);          
            Destroy(gameObject);        
    }
}
