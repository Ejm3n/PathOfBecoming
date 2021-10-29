using UnityEngine;
using UnityEngine.Events;
using Settings;

[RequireComponent(typeof(Collider2D))]
public abstract class InteractEvent : MonoBehaviour
{
    public UnityEvent onSuccess;
    public UnityEvent onFail;

    bool active = false;

    public virtual void Start_Event()
    {
        if (TryGetComponent(out Collider2D coll))
        {
            coll.enabled = false;
            onFail.AddListener(() => coll.enabled = true);
        }
    }

    private void Update()
    {
        if (active && ControlButtons.INTERACT)
            Start_Event();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        active = true;
        Interface.current.interactIndicator.gameObject.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        active = false;
        Interface.current.interactIndicator.gameObject.SetActive(false);
    }
}
