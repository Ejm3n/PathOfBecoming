using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class AreaCheckpointTrigger : CheckpointDialogue
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        StartDialogue();
        Destroy(gameObject);
    }
}
