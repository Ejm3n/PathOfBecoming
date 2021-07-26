using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public abstract class InventoryItem : MonoBehaviour,IBeginDragHandler,IEndDragHandler,IDragHandler
{
    RectTransform rectTransform;
    CanvasGroup canvasGroup;
    Button slot;
    protected Inventory inventory;

    protected bool draggable;
    public int stack { get; protected set; }

    public int amount { get; protected set; }

    public abstract void Use();
    protected abstract void Initialise();

    public void Add_To_Stack(int value = 1)
    {
        amount = Mathf.Min(stack, amount += value);
    }

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        slot = GetComponentInParent<Button>();
        Initialise();
    }

    public void Inventory_Link(Inventory inventory)
    {
        this.inventory = inventory;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (!draggable)
            return;
        Debug.Log("OnBeingDrag");
        canvasGroup.blocksRaycasts = false;
        slot.onClick?.Invoke();
    }
    public void OnDrag(PointerEventData eventData)
    {
        if (!draggable)
            return;
        rectTransform.anchoredPosition += eventData.delta;
        Debug.Log("OnDrag");
    } 
    public void OnEndDrag(PointerEventData eventData)
    {
        if (!draggable)
            return;
        Debug.Log("OnEndDrag");
        canvasGroup.blocksRaycasts = true;
        rectTransform.anchoredPosition = new Vector3(0, 0, 0);
        slot.onClick?.Invoke();
    }

    private void OnDestroy()
    {
        inventory.Sort_Inventory();
    }
}
