using UnityEngine;
using System;
using UnityEngine.Events;

[RequireComponent(typeof(Collider2D))]
public class PlaceForItem : MonoBehaviour
{
    [SerializeField] Transform placePosition;
    [SerializeField] ItemExecusion[] interactWith;

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonUp(0))
            Try_Interaction();
    }

    void Try_Interaction()
    {
        if (!DraggableItem.chosenItem)
            return;
        foreach (ItemExecusion item in interactWith)
            if (item.item == DraggableItem.chosenItem.item)
            {
                DraggableItem.chosenItem.Use();
                item.execution?.Invoke();
                break;
            }
    }

    public void Place_Item(GameObject item)
    {
        if (placePosition)
            Instantiate(item, placePosition).GetComponent<Collectible>().Attach(this);
    }

    public virtual void On_Detach()
    {

    }
}

[Serializable]
class ItemExecusion
{
    public Items item;
    public UnityEvent execution;
}
