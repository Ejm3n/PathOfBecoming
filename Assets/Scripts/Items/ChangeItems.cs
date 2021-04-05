using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeItems : MonoBehaviour
{
    [SerializeField] Inventory inventory;
    [SerializeField] GameObject whatToSpawn;
    [SerializeField] string WhatToTrade;
    int choosenSlot = -1;
    private void OnMouseDown()
    {
        Debug.Log("НАЖАТ НА ОБМЕН С АНЧУТКОЙ");
        for(int i = 0; i<inventory.isChosen.Length;i++)
        {
            if(inventory.isChosen[i])
            {
                choosenSlot = i;
                Debug.Log(inventory.slots[choosenSlot].transform.GetChild(0).gameObject.name + " itemtype in slot");
                break;
            }
        }
        if (choosenSlot!=-1 && inventory.slots[choosenSlot].transform.GetChild(0).gameObject.name == WhatToTrade + "(Clone)")
        {
            inventory.slots[choosenSlot].GetComponent<Slot>().SlotDropped(choosenSlot);
            for (int i = 0; i < inventory.slots.Length; i++)
            {
                if (inventory.isFull[i] == false)
                {
                    inventory.isFull[i] = true;
                    Instantiate(whatToSpawn, inventory.slots[i].transform);
                    Destroy(gameObject);
                    break;
                }
            }
        }
    }
}
