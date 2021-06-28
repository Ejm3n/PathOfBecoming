using UnityEngine;
using UnityEngine.Events;

public abstract class InteractEvent : MonoBehaviour
{
    public InteractController interactController;
    [SerializeField] protected UnityEvent onSuccess;
    [SerializeField] protected UnityEvent onFail;

    public abstract void Start_Event();

    private void OnMouseUp()
    {
        Start_Event();
    }
}
