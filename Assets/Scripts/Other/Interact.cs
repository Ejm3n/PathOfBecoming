﻿using UnityEngine;

public class Interact : MonoBehaviour
{
    [SerializeField] InteractAction interactAction;
    [SerializeField] InteractEvent interactEvent;
    [SerializeField] HintMap hintMap;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        interactAction.Set_Action(interactEvent.Start_Event);
        hintMap.Highlight();
    }
}
