using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections.Generic;
public class IfPlayerPutsSmthWrong : MonoBehaviour
{
    [SerializeField] Inventory inventory;
    [SerializeField] GameObject canvas;
    [SerializeField] GameObject[] whatToActivate;
    [SerializeField] string WhatToTrade;
    int currentActivation = 0;
    int choosenSlot = -1;
    private void OnMouseUp()
    {
        if (!this.IsPointerOverUIObject())
        {
            for (int i = 0; i < inventory.isChosen.Length; i++)//смотрим какой слот выбран
            {
                if (inventory.isChosen[i])
                {
                    choosenSlot = i;
                    break;
                }
            }
            if (inventory.slots[choosenSlot].transform.GetChild(0) != null && choosenSlot != -1 && inventory.slots[choosenSlot].transform.GetChild(0).gameObject.name == WhatToTrade + "(Clone)")
            {

                if (currentActivation < whatToActivate.Length)//включаем один из диалогов в случае неправильной постановки предмета
                {
                    whatToActivate[currentActivation].SetActive(true);
                    currentActivation++;
                }
                else//если иалоги заканчиваются то больше ниче говорить не надо и уничтожаем геймобжект
                {
                    Destroy(gameObject);
                }
            }
        }
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
