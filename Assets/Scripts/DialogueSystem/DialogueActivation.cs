using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueActivation : MonoBehaviour
{
    [SerializeField] int startNum;//строка с которой начать
    [SerializeField] int endOfThisDia;//до какого числа диалог
    [SerializeField] GameObject nextTriggerToActivate;//какой триггер включить следующим                                                  
    [SerializeField] DialogueSystem ds;//ссылка на диалоговую систему
    private void OnEnable()
    {
            ds.StartDialogue(startNum, endOfThisDia, nextTriggerToActivate); //при включении геймобжекты мы запускаем метод из диалоговой системе
            Destroy(gameObject); //а после удаляем объект
    }
}
