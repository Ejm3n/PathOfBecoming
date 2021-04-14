using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueChooseTrigger : MonoBehaviour
{
    [SerializeField] int choose1;//выбор1
    [SerializeField] int choose2;//выбор2
    [SerializeField] int endOfChoices;//нормальный текст идущий в любом случае ПОСЛЕ чойсов
    [SerializeField] GameObject nextTriggerToActivate;//какой триггер включить следующим
    [SerializeField] GameObject[] triggersToDelete;//какие триггеры удалить
    [SerializeField] DialogueSystem ds;//ссылка на диалоговую систему
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerController>() != null)//проверка зашел ли игрок
        {
            //var ds = FindObjectOfType<DialogueSystem>();
            ds.ChooseStart(choose1,choose2,endOfChoices,nextTriggerToActivate);//запускаем метод    
            for (int k = 0; k < triggersToDelete.Length; k++)//удаляем ненужные триггеры
            {
                if (triggersToDelete[k] != null)
                {
                    Destroy(triggersToDelete[k]);
                }
            }
            Destroy(gameObject);//удаляем сам объект со сцены, чтоб не мешал
        }
    }
}
