using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpFlower : MonoBehaviour
{
    Inventory inventory;
    public GameObject slot;
    bool foundFlower = false;
    GameObject madeFlower;
    private void Start()
    {
        inventory = FindObjectOfType<Inventory>();
    }
    private void OnMouseDown()
    {
        for (int i = 0; i < inventory.slots.Length; i++)
        {
            if(inventory.slots[i].GetComponentInChildren<Flower>()!=null)
            {
                foundFlower = true;
                Flower flower = inventory.slots[i].GetComponentInChildren<Flower>();
                int flowcount = Convert.ToInt32(flower.countText.text);
                Debug.Log(flowcount);
                if(flowcount < 3)
                {
                    flowcount++;
                    flower.countText.text = flowcount.ToString();
                    Destroy(gameObject);
                    break;
                }
            }          
        }
        for(int i =0;i<inventory.slots.Length;i++)
        {
            if (inventory.isFull[i] == false && !foundFlower)
            {
                inventory.isFull[i] = true;
                madeFlower = Instantiate(slot, inventory.slots[i].transform);
                madeFlower.GetComponent<Flower>().SlotNum = i;
                Destroy(gameObject);
                break;
            }
        }
        foundFlower = false;
    }
}
