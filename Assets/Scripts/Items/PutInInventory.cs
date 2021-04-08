using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PutInInventory : MonoBehaviour
{
    [SerializeField] Inventory inventory;
    public GameObject slot;

    private void OnEnable()
    {
        for (int i = 0; i < inventory.slots.Length; i++)
        {
            if (inventory.isFull[i] == false)
            {
                inventory.isFull[i] = true;
                Instantiate(slot, inventory.slots[i].transform);
                Destroy(gameObject);
                break;
            }
        }
    }
    
}
