using System;
[Serializable]
public class InventoryData
{
    public ItemData[] items;
    public InventoryData(ItemData[] items)
    {
        this.items = items;
    }
}

[Serializable]
public class ItemData
{
    public string itemName;
    public int amount;
    public int stack;
    public ItemData(string itemName, int amount, int stack)
    {
        this.itemName = itemName;
        this.amount = amount;
        this.stack = stack;
    }
}
