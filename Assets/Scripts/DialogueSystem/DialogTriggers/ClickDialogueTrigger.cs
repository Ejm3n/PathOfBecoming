
using UnityEngine.Events;

public class ClickDialogueTrigger : DialogueTrigger
{
    public UnityEvent dialogueStart;
    private void OnMouseUp()
    {
        dialogueStart?.Invoke();
        StartDialogue();
        Destroy(gameObject);
    }
}
