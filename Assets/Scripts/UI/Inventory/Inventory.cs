using System;
using System.Collections.Generic;
using UnityEngine;
public class Inventory : MonoBehaviour
{
    [SerializeField] Animator slotsAnim;
    bool shown = false;
    public Transform[] slots;

    List<Item> inventoryList = new List<Item>();

    CanvasGroup inventoryCG;

    private void Awake()
    {
        inventoryCG = GetComponent<CanvasGroup>();
    }

    public void ShowSlots()
    {
        shown = !shown;
        slotsAnim.SetBool("SlotsShown", shown);
    }

    public void SlotDropped(int slotNum)  
    {
        foreach (Transform child in slots[slotNum])
            Destroy(child.gameObject);
    }

    private void OnDisable()
    {
        slotsAnim.SetBool("SlotsShown", true);
        shown = true;
    }

    public InventoryData SaveInvetnoryData()
    {
        ItemData[] items = new ItemData[inventoryList.Count];
        for (int i = 0;i< items.Length; i++)
            items[i] = inventoryList[i].Get_ItemData();
        return new InventoryData(items);
    }

    public void LoadInventoryData(InventoryData data)
    {
       for(int i = 0; i < data.items.Length; i++)
       {
            ItemData item = data.items[i];
            GameObject prefab = Resources.Load<GameObject>(Item.path + item.itemName);
            Add_To_Inventory(prefab);
            inventoryList[i].Set_Item_Parameters(item.amount, item.stack);
       }
    }

    public bool Add_To_Inventory(GameObject item)
    {
        if (!item.TryGetComponent(out Item itemScript)) //invalid item
            return false;

        int itemIndex = Get_Item_Index_By_Type(itemScript.GetType());

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

    public void Add_to_Inventory_Trigger(GameObject item)
    {
        Add_To_Inventory(item);
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

    public void Remove_From_Inventory_Trigger(GameObject item)
    {
        Remove_From_Inventory(item.GetComponent<Item>().GetType(), true);
    }

    public bool Remove_From_Inventory(Type type, bool force = false)
    {
        int itemIndex = Get_Item_Index_By_Type(type, force);
        if (itemIndex == -1)
            return false;
        inventoryList.RemoveAt(itemIndex);
        SlotDropped(itemIndex);
        Sort_Inventory();
        return true;
    }

    int Get_Item_Index_By_Type(Type type, bool force = false)
    {
        for (int i = 0; i < inventoryList.Count; i++)
            if (inventoryList[i].GetType() == type && 
                (inventoryList[i].amount < inventoryList[i].stack || force))
                return i;
        return -1;
    }

    int Get_Item_Index(Item item)
    {
        for (int i = 0; i < inventoryList.Count; i++)
            if (inventoryList[i] == item)
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

    public void Enable_Inventory()
    {
        inventoryCG.alpha = 1;
        inventoryCG.blocksRaycasts = true;
        inventoryCG.interactable = true;
        Engine.current.dialogueSystem.canUseInventory = true;
    }
}
