using UnityEngine;
public class Flower : Item
{
    [SerializeField] float healAmount;

    Health health;

    protected override void Set_Item_Parameters()
    {
        stack = 5;
        amount = 1;

        health = Engine.current.player.GetComponent<Health>();
    }

    public override void Use()
    {
        health.Heal(healAmount);
        base.Use();
    }
}
