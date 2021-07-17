using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PutInInventory : MonoBehaviour
{
    [SerializeField] Inventory inventory;
    //public GameObject slot;
    //GameObject newSlot;
    public string filePath;
    [SerializeField] bool onEnableActive;
    private void OnEnable()
    {
        if (onEnableActive)
            PutIn();
    }
    protected void PutIn()
    {
        for (int i = 0; i < inventory.slots.Length; i++)
        {
            if (inventory.isFull[i] == false)
            {
                inventory.isFull[i] = true;
                //Instantiate(slot, inventory.slots[i].transform);
                Instantiate(Resources.Load(filePath, typeof(GameObject)), inventory.slots[i].transform);
                //newSlot = Resources.Load<GameObject>(filePath);
                //Instantiate( newSlot,inventory.slots[i].transform);
                Slot.SlotCount[i] = 1;
                Slot.SlotItems[i] = filePath;
                Destroy(gameObject);
                break;
            }
        }
    }

}
