using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    [SerializeField] int slotNum;
    [SerializeField] GameObject inventory;
    private Inventory inv;
    public string ItemType;
    private void Start()
    {
        inv = inventory.GetComponent<Inventory>();
    }
    public void SlotPressed()
    {
        for (int i = 0; i < inv.isChosen.Length; i++)
        {
            if(i == slotNum)
            {
                inv.isChosen[slotNum] = !inv.isChosen[slotNum];
                if(inv.isChosen[slotNum])
                {
                    gameObject.GetComponent<Image>().color = Color.yellow ;
                }
                else
                {
                    gameObject.GetComponent<Image>().color = Color.white;
                }
                
            }
            else
            {
                inv.isChosen[i] = false;
                inv.slots[i].GetComponent<Image>().color = Color.white;
            }
           
            
        }
    }
    public void SlotDropped(int slotNum)
    {
        foreach (Transform child in transform)
        {
            GameObject.Destroy(child.gameObject);
        }
        inv.isFull[slotNum] = false;
        SlotPressed();
    }
}
