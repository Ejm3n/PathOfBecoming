using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[Serializable]
public class InventoryData
{
    public string[] InventorySlots;
    public int[] InventoryCount;
    public InventoryData()
    {
        InventorySlots = Slot.SlotItems;
        InventoryCount = Slot.SlotCount;
    }
}
