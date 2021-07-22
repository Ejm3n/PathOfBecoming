using UnityEngine;

public class PlaceLetterToInventory : MonoBehaviour
{
    [SerializeField]CanvasGroup letter;

    private void OnMouseUp()
    {
        letter.alpha = 1 ;
        letter.interactable = true;
        letter.blocksRaycasts = true;
    }
}

