using UnityEngine;

public abstract class InteractEvent : MonoBehaviour
{
    public InteractController interactController;

    public abstract void Start_Event();

    private void OnMouseUp()
    {
        Start_Event();
    }
}
