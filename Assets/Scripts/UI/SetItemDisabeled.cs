using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetItemDisabeled : MonoBehaviour
{
    private CanvasGroup cg;
    private void Start()
    {
        cg = gameObject.GetComponent<CanvasGroup>();
    }
    public void OnClick()
    {
        cg.alpha = 0;
        cg.interactable = false;
        cg.blocksRaycasts = false;
    }
}
