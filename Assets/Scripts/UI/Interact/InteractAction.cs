using System;
using UnityEngine;

[RequireComponent(typeof (BoxCollider2D))]
public class InteractAction : MonoBehaviour
{
    Action action;
    
    public void Set_Action(Action action)
    {
        this.action = action;
    }
    private void OnMouseUp()
    {
        action();
    }
}
