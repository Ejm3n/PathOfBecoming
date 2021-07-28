using UnityEngine;
using UnityEngine.EventSystems;

public abstract class DraggableItem : Item, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    public Items item;

    RectTransform rectTransform;
    CanvasGroup canvasGroup;

    public virtual void Use()
    {
        Remove_From_Stack();
    }

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("OnBeingDrag");
        canvasGroup.blocksRaycasts = false;
        inventory.Choose_Item(this);
    }
    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta;
        Debug.Log("OnDrag");
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("OnEndDrag");
        canvasGroup.blocksRaycasts = true;
        rectTransform.anchoredPosition = Vector3.zero;
    }
}
public enum Items
{
    //List of draggable Items
    Spider, Box, EmptyBox, Desk, DoorKey, Plate
}