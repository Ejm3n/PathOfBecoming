using UnityEngine;

public class HoleChip : Chip
{
    private void OnMouseDown()
    {
        if (!chipMoving && Input.GetMouseButtonDown(0))
            field.queue.Enqueue(new QueueItem(index, typeof(MouseChip)));
    }
}
