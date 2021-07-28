using UnityEngine;

public class Spider : DraggableItem
{
    [SerializeField] GameObject addToInventory;
    public override void Use()
    {
        inventory.Add_To_Inventory(addToInventory);
        base.Use();
    }
}
