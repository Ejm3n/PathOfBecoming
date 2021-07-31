using System.Collections;
using UnityEngine;

public class ILevel1 : Interface
{
    [SerializeField] GameObject inventoryGuideTrigger;
    [SerializeField] GameObject startingInventory;
    public void Inventory_Guide()
    {
        StartCoroutine(Show_Inventory());
    }

    public void Spellbook_Guide()
    {
        engine.dialogueSystem.SetUI(false);
        spellBook.Enable_Spellbook();
    }

    IEnumerator Show_Inventory()
    {
        engine.dialogueSystem.SetUI(false);
        inventory.Enable_Inventory();
        yield return new WaitForSeconds(2);
        engine.dialogueSystem.SetUI(false);
        inventoryGuideTrigger.SetActive(true);
    }

    public void StartingInventory()
    {
        inventory.Add_To_Inventory(startingInventory);
    }
}
