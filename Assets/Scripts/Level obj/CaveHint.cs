using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaveHint : MonoBehaviour
{
    [SerializeField] CanvasGroup hintCG;
    [SerializeField] HintMap hintMap;
    private void OnMouseUp()
    {
        hintCG.alpha = 1;
        hintCG.interactable = true;
        hintCG.blocksRaycasts = true;
        hintMap.Highlight(2);
    }

}
