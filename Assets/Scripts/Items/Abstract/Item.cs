using UnityEngine;
using UnityEngine.UI;

public abstract class Item : MonoBehaviour
{
    [SerializeField] Text countText;

    protected Inventory inventory;

    public int stack { get; protected set; }

    public int amount { get; protected set; }

    protected virtual void Set_Item_Parameters()
    {
        amount = 1;
        stack = 1;
    }

    protected void Show_Amount()
    {
        if (stack > 1)
            countText.text = amount.ToString();
        else
            countText.text = null;
    }

    public void Add_To_Stack(int value = 1)
    {
        amount = Mathf.Min(stack, amount += value);
        Show_Amount();
    }

    public void Remove_From_Stack(int value = 1)
    {
        if (amount < value)
            return;
        amount -= value;
        Show_Amount();
        if (amount == 0)
            inventory.Remove_From_Inventory(this);

    }

    public void Initialise(Inventory inventory)
    {
        this.inventory = inventory;
        Set_Item_Parameters();
    }
}
