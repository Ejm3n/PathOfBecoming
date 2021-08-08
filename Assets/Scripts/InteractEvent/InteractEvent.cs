﻿using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider2D))]
public abstract class InteractEvent : MonoBehaviour
{
    public UnityEvent onSuccess;
    public UnityEvent onFail;

    public virtual void Start_Event()
    {
        if (TryGetComponent(out Collider2D coll))
        {
            coll.enabled = false;
            onFail.AddListener(() => coll.enabled = true);
        }
    }

    private void OnMouseUp()
    {
        Start_Event();
    }
}
