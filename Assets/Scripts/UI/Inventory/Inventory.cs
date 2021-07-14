using UnityEngine;
using UnityEngine.UI;
public class Inventory : MonoBehaviour
{
    [SerializeField] Animator slotsAnim;
    bool hidden = false;
    public bool[] isFull;
    public bool[] isChosen;
    public GameObject[] slots;
    
    public void ShowSlots()
    {
        hidden = !hidden;
        slotsAnim.SetBool("SlotsShown", hidden);
    }
    public void SlotPressed(int slotNum)
    {
        Debug.Log("SlotPressed + " + slotNum);
        for (int i = 0; i < isChosen.Length; i++)
        {
            if (i == slotNum)
            {
                isChosen[slotNum] = !isChosen[slotNum];
               
            }
            else
            {
                isChosen[i] = false;
                
            }
        }
    }
    public void SlotDropped(int slotNum)  
    {
        foreach (Transform child in slots[slotNum].transform)
        {
            GameObject.Destroy(child.gameObject);
        }
        Slot.SlotCount[slotNum] = 0;
        Slot.SlotItems[slotNum] = "";
        isFull[slotNum] = false;
        SlotPressed(slotNum);
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
        GameObject slotInst = Instantiate(Resources.Load(path, typeof(GameObject)), slots[slotNum].transform) as GameObject;
        isFull[slotNum] = true;
        Slot.SlotCount[slotNum] = count;
        Slot.SlotItems[slotNum] = path;
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
}
