using UnityEngine;
using System;
using UnityEngine.Events;

[RequireComponent(typeof(Collider2D))]
public class PlaceForItem : MonoBehaviour
{
    [SerializeField] Transform placePosition;
    [SerializeField] DialogueTrigger failDialog;
    [SerializeField] ItemExecusion[] interactWith;

    bool attachedItem = false;

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
                return;
            }
        Cannot_Interact();
    }

    void Cannot_Interact()
    {
        if(failDialog)
            failDialog.StartDialogue();
    }

    public void Place_Item(GameObject item)
    {
        if (placePosition && !attachedItem)
            Instantiate(item, placePosition).GetComponent<Collectible>().Attach(this);
        attachedItem = true;
    }

    public virtual void On_Detach()
    {
        attachedItem = false;
    }
}

[Serializable]
class ItemExecusion
{
    public Items item;
    public UnityEvent execution;
}
