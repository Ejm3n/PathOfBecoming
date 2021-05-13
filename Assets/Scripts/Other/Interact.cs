using UnityEngine;

public class Interact : MonoBehaviour
{
    [SerializeField] InteractButton interactButton;
    [SerializeField] Sprite interactSprite;
    [SerializeField] InteractEvent interactEvent;

    Collider2D coll;

    private void Start()
    {
        coll = GetComponent<Collider2D>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        interactEvent.Set_Trigger(coll);
        interactButton.gameObject.SetActive(true);
        interactButton.Set_Button(interactSprite, interactEvent.Start_Event);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        interactButton.gameObject.SetActive(false);
    }
}
