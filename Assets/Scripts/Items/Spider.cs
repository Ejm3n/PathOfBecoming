using UnityEngine;

public class Spider : InventoryItem
{
    [SerializeField] GameObject closedBox;
    public override void Use()
    {
        inventory.Add_To_Inventory(closedBox);
        Destroy(gameObject);
    }

    protected override void Initialise()
    {
        draggable = true;
        stack = 1;
        amount = 1;
    }
}
