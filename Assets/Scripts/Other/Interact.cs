using UnityEngine;

public class Interact : MonoBehaviour
{
    [SerializeField] InteractAction interactAction;
    [SerializeField] ParticleSystem interactParticle;
    [SerializeField] InteractEvent interactEvent;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        interactParticle.Play();
        interactAction.Set_Action(interactEvent.Start_Event);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        interactParticle.Stop();
    }
}
