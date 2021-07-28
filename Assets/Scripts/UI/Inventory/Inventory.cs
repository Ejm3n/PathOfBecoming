using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Inventory : MonoBehaviour
{
    [SerializeField] Animator slotsAnim;
    bool hidden = false;
    public Transform[] slots;

    List<Item> inventoryList = new List<Item>();

    int chosenSlot;
    
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

    public void Choose_Item(Item item)
    {
        chosenSlot = inventoryList.IndexOf(item);
    }

    public void Add_To_Inventory(GameObject item)
    {
        if (!item.TryGetComponent(out Item itemScript)) //invalid item
            return;
        int itemIndex = Get_Item_Index(itemScript);

        if (itemIndex != -1) //we can add item to stack
        {
            inventoryList[itemIndex].Add_To_Stack();
            return;
        }

        if (inventoryList.Count >= slots.Length) //inventory is full
            return;

        //create new item in inventory
        inventoryList.Add(itemScript);
        itemScript.Inventory_Link(this);
        Instantiate(item, slots[inventoryList.Count - 1]);
    }

    public void Remove_From_Inventory(Item item)
    {
        int itemIndex = Get_Item_Index(item);
        if (itemIndex == -1)
            return;
        inventoryList.RemoveAt(itemIndex);
        SlotDropped(itemIndex);
        Sort_Inventory();
    }

    public Item Get_Chosen_Item()
    {
        return inventoryList[chosenSlot];
    }

    public int Get_Item_Index(Item item)
    {
        for (int i = 0; i < inventoryList.Count; i++)
            if (inventoryList[i] == item && inventoryList[i].amount < inventoryList[i].stack)
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

    public void Use_Chosen_Item()
    {

    }
}
