using UnityEngine;
using UnityEngine.EventSystems;

public abstract class DraggableItem : Item, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    public Items item;

    public static DraggableItem chosenItem;

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
        canvasGroup.blocksRaycasts = false;
        chosenItem = this;
    }
    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta;
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = true;
        rectTransform.anchoredPosition = Vector3.zero;
        chosenItem = null;
    }
}
public enum Items
{
    //List of draggable Items
    Spider, Box, EmptyBox, DoorKey, Plate
}