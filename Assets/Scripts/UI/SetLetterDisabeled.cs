using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetLetterDisabeled : MonoBehaviour
{
    [SerializeField] GameObject diaTrigger;
    bool first;
    private CanvasGroup cg;
    private void Start()
    {
        first = true;
        cg = gameObject.GetComponent<CanvasGroup>();
    }
    public void OnClick()
    {
        cg.alpha = 0;
        cg.interactable = false;
        cg.blocksRaycasts = false;
        if (first)
        {
            diaTrigger.SetActive(true);
            first = false;
        }
        
    }
}