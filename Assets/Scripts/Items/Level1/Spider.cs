using UnityEngine;

public class Spider : Item
{
    [SerializeField] GameObject addToInventory;

    public override void Use()
    {
        inventory.Add_To_Inventory(addToInventory);
        base.Use();
    }
}
