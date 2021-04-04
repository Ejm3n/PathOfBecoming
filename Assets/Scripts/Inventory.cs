using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
}
