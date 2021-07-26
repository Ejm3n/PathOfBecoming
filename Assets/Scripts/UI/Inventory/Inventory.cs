using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Inventory : MonoBehaviour
{
    [SerializeField] Animator slotsAnim;
    bool hidden = false;
    public Transform[] slots;

    List<InventoryItem> inventoryList = new List<InventoryItem>();

    int chosenSlot;
    
    public void ShowSlots()
    {
        hidden = !hidden;
        slotsAnim.SetBool("SlotsShown", hidden);
    }
    public void SlotPressed(int slotNum)
    {
        chosenSlot = slotNum;
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
        ClearInventory();
       for(int i = 0; i<slots.Length;i++)
        {
            if(ID.InventoryCount[i]!=0 && ID.InventorySlots[i]!="")
                LoadSlot(i, ID.InventorySlots[i], ID.InventoryCount[i]);
        }
    }
    void LoadSlot(int slotNum,string path, int count)
    {
        GameObject slotInst = Instantiate(Resources.Load(path, typeof(GameObject)), slots[slotNum]) as GameObject;
        if(count>1)
        {
            slotInst.GetComponentInChildren<Flower>().countText.text = count.ToString();//костыль - надо переделать
        }
    }
    void ClearInventory()
    {
        for(int i = 0;i<slots.Length;i++)
        {
            SlotDropped(i);
        }
    }

    public void Add_To_Inventory(GameObject item)
    {
        if (!item.TryGetComponent(out InventoryItem itemScript)) //invalid item
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

    public void Remove_From_Inventory(InventoryItem item) //а надо ли нам это...
    {
        int itemIndex = Get_Item_Index(item);
        if (itemIndex == -1)
            return;
        inventoryList.RemoveAt(itemIndex);
        SlotDropped(itemIndex);
    }

    public InventoryItem Get_Chosen_Item()
    {
        return inventoryList[chosenSlot];
    }

    public int Get_Item_Index(InventoryItem item)
    {
        for (int i = 0; i < inventoryList.Count; i++)
            if (inventoryList[i] == item && inventoryList[i].amount < inventoryList[i].stack)
                return i;
        return -1;
    }

    public void Sort_Inventory()
    {
        int emptySlot = -1;
        for (int i =0;i< slots.Length; i++)
        {
            if (slots[i].childCount == 0)
                emptySlot = i;
            else if (slots[i].childCount > 0 && emptySlot != -1 && emptySlot < i) //previous slot is empty
            {
                foreach(Transform child in slots[i])
                {
                    child.SetParent(slots[i - 1]);
                    child.localPosition = Vector3.zero;
                }
                emptySlot = i; //now this slot is empty
            }
        }
    }

    public void Use_Chosen_Item()
    {

    }
}
