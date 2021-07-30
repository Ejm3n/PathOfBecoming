using System.Collections;
using UnityEngine;

public class ILevel1 : Interface
{
    public void Inventory_Guide()
    {
        StartCoroutine(Show_Inventory());
    }

    IEnumerator Show_Inventory()
    {
        engine.dialogueSystem.SetUI(false);
        CanvasGroup inventoryCanvas = inventory.GetComponent<CanvasGroup>();
        inventoryCanvas.alpha = 1;
        inventoryCanvas.blocksRaycasts = true;
        inventoryCanvas.interactable = true;
        yield return new WaitForSeconds(2);
        engine.dialogueSystem.canUseInventory = true;
        engine.dialogueSystem.SetUI(true);
    }
}
