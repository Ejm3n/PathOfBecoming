using UnityEngine.EventSystems;

public abstract class ClickableItem : Item, IPointerClickHandler
{
    protected virtual void On_Click()
    {
        Remove_From_Stack();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        On_Click();
    }
}
