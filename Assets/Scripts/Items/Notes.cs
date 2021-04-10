using UnityEngine;
public class Notes : MonoBehaviour
{
    public void OnClick()
    {
       var notes = GameObject.FindGameObjectWithTag("Notes").GetComponent<CanvasGroup>();
        notes.alpha = 1;
        notes.interactable = true;
        notes.blocksRaycasts = true;
    }
}
