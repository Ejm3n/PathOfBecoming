using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FilledVessel : Item
{
    public override void Use()
    {
        inventory.Add_To_Inventory(Resources.Load<GameObject>(path + "EmptyVessel(Level2)"));
        base.Use();
    }
}
