using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider2D))]
public abstract class InteractEvent : MonoBehaviour
{
    public UnityEvent onSuccess;
    public UnityEvent onFail;

    [SerializeField] Sprite indicator;

    public static InteractEvent current { get; protected set; }

    public virtual void Start_Event()
    {
        if (TryGetComponent(out Collider2D coll))
        {
            coll.enabled = false;
            onFail.AddListener(() => coll.enabled = true);
        }
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        current = this;
        Engine.current.playerController.interactIndicator.sprite = indicator;
        Engine.current.playerController.interactIndicator.gameObject.SetActive(true);
    }

    protected virtual void OnTriggerExit2D(Collider2D collision)
    {
        current = null;
        Engine.current.playerController.interactIndicator.gameObject.SetActive(false);
    }
}
