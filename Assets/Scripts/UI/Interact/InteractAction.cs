using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof (BoxCollider2D))]
public class InteractAction : MonoBehaviour
{
    Action action;
    
    public void Set_Action(Action action)
    {
        Debug.Log("set action");
        this.action = action;
    }
    private void OnMouseUp()
    {
        action();
    }
}
