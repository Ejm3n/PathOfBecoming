using System;
using UnityEngine;
using UnityEngine.UI;

public class Flower : ClickableItem
{
    [SerializeField] float healAmount;

    Health health;

    protected override void Initialise()
    {
        stack = 5;
        amount = 1;

        health = Engine.current.player.GetComponent<Health>();
    }

    protected override void On_Click()
    {
        health.Heal(healAmount);
        base.On_Click();
    }
}
