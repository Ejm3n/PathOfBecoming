
using UnityEngine.Events;

public class ClickDialogueTrigger : DialogueTrigger
{
    public UnityEvent dialogueStart;
    private void OnMouseUp()
    {
        StartDialogue();
        Destroy(gameObject);
    }
}
