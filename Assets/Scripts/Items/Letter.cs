using UnityEngine;
public class Letter : MonoBehaviour
{
    
    public void OnClick()
    {
        var letter = GameObject.FindGameObjectWithTag("Letter").GetComponent<CanvasGroup>();
        letter.alpha = 1;
        letter.interactable = true;
        letter.blocksRaycasts = true;
    }
}
