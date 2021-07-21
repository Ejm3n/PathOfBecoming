using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaveHint : MonoBehaviour
{
    [SerializeField] CanvasGroup hintCG;
    private void OnMouseUp()
    {
        hintCG.alpha = 1;
        hintCG.interactable = true;
        hintCG.blocksRaycasts = true;
    }

}
