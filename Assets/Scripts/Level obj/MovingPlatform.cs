using UnityEngine;

public class MovingPlatform : MonoBehaviour
{

    PlayerController playerController;
    private void Awake()
    {
        playerController = Engine.current.player.GetComponent<PlayerController>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.transform.parent = transform;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        collision.transform.parent = null;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(playerController.isGround)
            collision.transform.parent = transform;
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        collision.transform.parent = null;
    }
}
