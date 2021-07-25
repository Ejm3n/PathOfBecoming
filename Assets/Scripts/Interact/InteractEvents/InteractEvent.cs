using UnityEngine;
using UnityEngine.Events;

public abstract class InteractEvent : MonoBehaviour
{
    public UnityEvent onSuccess;
    public UnityEvent onFail;

    public abstract void Start_Event();

    private void OnMouseUp()
    {
        Start_Event();
    }
}
