using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ChangeItems : InteractEvent
{
    [SerializeField] Inventory inventory;
    [SerializeField] GameObject whatToSpawn;
    [SerializeField] string WhatToTrade;
    int choosenSlot = -1;
    [SerializeField] GameObject canvas;
    public string filePath;
    public override void Start_Event()
    {
        for (int i = 0; i < inventory.isChosen.Length; i++)//узнаем какой слот выбран
        {
            if (inventory.isChosen[i])
            {
                choosenSlot = i;
                break;
            }
        }
        if (choosenSlot != -1 && inventory.slots[choosenSlot].transform.childCount >= 1 && inventory.slots[choosenSlot].transform.GetChild(0).gameObject.name == WhatToTrade + "(Clone)")//прлверка если выбран нужный предмет
        {
            inventory.SlotDropped(choosenSlot);
            for (int i = 0; i < inventory.slots.Length; i++)
            {
                if (inventory.isFull[i] == false)//создаем в пустом слоте предмет
                {
                    inventory.isFull[i] = true;
                    Instantiate(Resources.Load(filePath, typeof(GameObject)), inventory.slots[i].transform);
                    Slot.SlotCount[i] = 1;
                    Slot.SlotItems[i] = filePath;
                    onSuccess?.Invoke();
                    Destroy(gameObject);
                    break;
                }
                else if (i == inventory.slots.Length - 1)
                    onFail?.Invoke();
            }
        }
    }
    private void OnMouseOver()
    {
        for (int i = 0; i < inventory.isChosen.Length; i++)//узнаем какой слот выбран
        {
            if (inventory.isChosen[i])
            {
                choosenSlot = i;
                break;
            }
        }
        if(choosenSlot!=-1 && Input.GetMouseButtonUp(0))
            Start_Event();
    }
    private bool IsPointerOverUIObject()
    {
        // get current pointer position and raycast it
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);


        // check if the target is in the UI
        foreach (RaycastResult r in results)
        {
            bool isUIClick = r.gameObject.transform.IsChildOf(this.canvas.transform);
            if (isUIClick)
            {
                return true;
            }
        }
        return false;

    }
}