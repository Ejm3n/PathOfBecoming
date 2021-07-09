using UnityEngine;

public class DialogueChooseTrigger : DialogueTrigger
{
    [SerializeField] int secondChoiceStart;//выбор2

    private void OnTriggerEnter2D(Collider2D collision)
    {
        transform.parent.GetComponent<DialogueSystem>().ChooseStart(startNum, secondChoiceStart, endOfThisDia, onTrigger);
        Destroy(gameObject);
    }
}
