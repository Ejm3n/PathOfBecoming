using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider2D))]
public abstract class InteractEvent : MonoBehaviour
{
    public InteractController interactController;
    public UnityEvent onSuccess;
    public UnityEvent onFail;

    public abstract void Start_Event();

    private void OnMouseUp()
    {
        Start_Event();
    }
}
