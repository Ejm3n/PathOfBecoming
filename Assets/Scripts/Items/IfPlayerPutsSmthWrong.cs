using UnityEngine;

public class IfPlayerPutsSmthWrong : MonoBehaviour
{
    [SerializeField] Inventory inventory;
    [SerializeField] GameObject[] whatToActivate;
    [SerializeField] string WhatToTrade;
    int currentDialogue = 0;
    int choosenSlot = -1;
    private void OnMouseDown()
    {
        for (int i = 0; i < inventory.isChosen.Length; i++)
        {
            if (inventory.isChosen[i])
            {
                choosenSlot = i;
                break;
            }
        }
        if (inventory.slots[choosenSlot].transform.GetChild(0) != null && choosenSlot != -1 && inventory.slots[choosenSlot].transform.GetChild(0).gameObject.name == WhatToTrade + "(Clone)")
        {

            if (currentDialogue < whatToActivate.Length)
            {

                whatToActivate[currentDialogue].SetActive(true);
                currentDialogue++;
            }
            else
            {

                Destroy(gameObject);
            }

        }
    }
}
