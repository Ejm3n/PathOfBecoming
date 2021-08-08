using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class AreaDialogTrigger : DialogueTrigger
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        StartDialogue();
        Destroy(gameObject);
    }
}
