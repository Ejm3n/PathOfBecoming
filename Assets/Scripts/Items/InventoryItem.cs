using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public abstract class InventoryItem : MonoBehaviour,IBeginDragHandler,IEndDragHandler,IDragHandler
{
    RectTransform rectTransform;
    CanvasGroup canvasGroup;
    Button slot;

    public abstract void Use();

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        slot = GetComponentInParent<Button>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("OnBeingDrag");
        canvasGroup.blocksRaycasts = false;
        slot.onClick?.Invoke();
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
        rectTransform.anchoredPosition = new Vector3(0, 0, 0);
        slot.onClick?.Invoke();
    }
}
