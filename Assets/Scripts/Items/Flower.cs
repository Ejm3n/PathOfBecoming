using System;
using UnityEngine;
using UnityEngine.UI;

public class Flower : MonoBehaviour
{
    Health health;
    [HideInInspector] public Text countText;
    Inventory inventory;
    [HideInInspector] public int SlotNum;
    private void Start()
    {
        health = FindObjectOfType<Health>();
        countText = GetComponentInChildren<Text>();
        inventory = FindObjectOfType<Inventory>();  
    }
    public void OnFlowerClick()
    {
        //if(health.!=1)
        //{
        //    int count = Convert.ToInt32(countText.text);
        //    hpImage.fillAmount += 0.25f;
        //    if (count>1)
        //    {
        //        count--;
        //        Slot.SlotCount[SlotNum]--;
        //        countText.text = count.ToString();
        //    }
        //    else if(count == 1)
        //    {
        //        inventory.SlotDropped(SlotNum);
        //        Destroy(gameObject);
        //    }          
        //}
    }
}
