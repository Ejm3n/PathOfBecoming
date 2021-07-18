using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventoryItem : MonoBehaviour, IPointerDownHandler, IBeginDragHandler,IEndDragHandler,IDragHandler
{
    RectTransform rectTransform;
    CanvasGroup canvasGroup;
    Button slot;
    private void Start()
    {
        rectTransform = gameObject.GetComponent<RectTransform>();
        canvasGroup = gameObject.GetComponent<CanvasGroup>();
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
    public void OnPointerDown(PointerEventData eventData)
    {
        

        Debug.Log("onpointerdown");
    }
}
