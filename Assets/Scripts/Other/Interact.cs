using UnityEngine;
using UnityEngine.UI;

public class Interact : MonoBehaviour
{
    [SerializeField] InteractButton interactButton;
    [SerializeField] Sprite interactSprite;
    [SerializeField] InteractEvent interactEvent;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        interactButton.gameObject.SetActive(true);
        interactButton.Set_Button(interactSprite, () => interactEvent.Start_Event());
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        interactButton.gameObject.SetActive(false);
    }
}
