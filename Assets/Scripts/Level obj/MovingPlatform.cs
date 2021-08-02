using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.transform.parent = transform;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        collision.transform.parent = null;
    }
}
