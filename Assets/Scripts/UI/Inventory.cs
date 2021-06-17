using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Inventory : MonoBehaviour
{
    [SerializeField] Animator slotsAnim;
    bool hidden = false;
    public bool[] isFull;
    public bool[] isChosen;
    public GameObject[] slots;
    [SerializeField] Image[] borders;
    public void ShowSlots()
    {
        hidden = !hidden;
        slotsAnim.SetBool("SlotsShown", hidden);
    }
    public void SlotPressed(int slotNum)
    {
        for (int i = 0; i < isChosen.Length; i++)
        {
            if (i == slotNum)
            {
                isChosen[slotNum] = !isChosen[slotNum];
                if (isChosen[slotNum])
                {
                    Debug.Log("sokdfois");
                    borders[i].enabled = true;
                }
                else
                {
                    Debug.Log("aaaaa");
                    borders[i].enabled = false;
                }
            }
            else
            {
                isChosen[i] = false;
                borders[i].enabled = false;
            }
        }
    }
    public void SlotDropped(int slotNum)  
    {
        foreach (Transform child in slots[slotNum].transform)
        {
            GameObject.Destroy(child.gameObject);
        }
        isFull[slotNum] = false;
        SlotPressed(slotNum);
    }
    private void OnDisable()
    {
        slotsAnim.SetBool("SlotsShown", true);
        hidden = true;
    }
}
