using System.Collections.Generic;
using UnityEngine;
public class Inventory : MonoBehaviour
{
    [SerializeField] Animator slotsAnim;
    bool hidden = false;
    public Transform[] slots;

    List<Item> inventoryList = new List<Item>();
    
    public void ShowSlots()
    {
        hidden = !hidden;
        slotsAnim.SetBool("SlotsShown", hidden);
    }

    public void SlotDropped(int slotNum)  
    {
        foreach (Transform child in slots[slotNum])
            Destroy(child.gameObject);
    }

    private void OnDisable()
    {
        slotsAnim.SetBool("SlotsShown", true);
        hidden = true;
    }

    public InventoryData SaveInvetnoryData()
    {
        return new InventoryData();
    }

    public void LoadInventoryData(InventoryData ID)
    {
        //TODO
    }

    void LoadSlot()
    {
        //TODO
    }

    void ClearInventory()
    {
        for(int i = 0;i<slots.Length;i++)
        {
            SlotDropped(i);
        }
    }

    public bool Add_To_Inventory(GameObject item)
    {
        if (!item.TryGetComponent(out Item itemScript)) //invalid item
            return false;

        int itemIndex = Get_Item_Index(itemScript);

        if (itemIndex != -1) //we can add item to stack
        {
            inventoryList[itemIndex].Add_To_Stack();
            return true;
        }

        if (inventoryList.Count >= slots.Length) //inventory is full
            return false;

        //create new item in inventory
        itemScript = Instantiate(item, slots[inventoryList.Count]).GetComponent<Item>();
        itemScript.Initialise(this);
        inventoryList.Add(itemScript);
        return true;
    }

    public bool Remove_From_Inventory(Item item)
    {
        int itemIndex = Get_Item_Index(item);
        if (itemIndex == -1)
            return false;
        inventoryList.RemoveAt(itemIndex);
        SlotDropped(itemIndex);
        Sort_Inventory();
        return true;
    }

    int Get_Item_Index(Item item)
    {
        for (int i = 0; i < inventoryList.Count; i++)
            if (inventoryList[i].GetType() == item.GetType() && inventoryList[i].amount < inventoryList[i].stack)
                return i;
        return -1;
    }

    void Sort_Inventory()
    {
        for (int i = 0; i < inventoryList.Count; i++)
        {
            Transform item = inventoryList[i].gameObject.transform;
            item.SetParent(slots[i]);
            item.localPosition = Vector3.zero;
        }
    }
}
