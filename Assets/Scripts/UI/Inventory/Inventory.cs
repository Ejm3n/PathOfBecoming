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
        foreach (Transform child in slots[slotNum].transform)
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
        if (inventoryList.Count >= slots.Length)
        {
            Debug.Log("Inventory is full!");
            return;
        }
        inventoryList.Add(item.GetComponent<InventoryItem>());
        Instantiate(item, slots[inventoryList.Count - 1]);
    }

    public void Remove_From_Inventory(InventoryItem item)
    {
        int itemIndex = -1;
        for (int i = 0; i < inventoryList.Count; i++)
            if (inventoryList[i] == item)
            {
                itemIndex = i;
                break;
            }
        inventoryList.RemoveAt(itemIndex);
        SlotDropped(itemIndex);
    }

    public InventoryItem Get_Chosen_Item()
    {
        return inventoryList[chosenSlot];
    }

    public void Use_Chosen_Item()
    {

    }
}
