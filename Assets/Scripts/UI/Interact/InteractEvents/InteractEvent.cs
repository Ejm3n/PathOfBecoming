using UnityEngine;

public abstract class InteractEvent : MonoBehaviour
{
    public Collider2D eventTrigger;

    public abstract void Start_Event();

    public void Set_Trigger(Collider2D trigger)
    {
        eventTrigger = trigger;
    }
}
