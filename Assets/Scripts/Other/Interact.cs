using UnityEngine;

public class Interact : MonoBehaviour
{
    PlayerController controller;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        controller = collision.GetComponent<PlayerController>();
        controller.engine.hintMap.Highlight();
    }
}
