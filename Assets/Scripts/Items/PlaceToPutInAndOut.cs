using UnityEngine;

public class PlaceToPutInAndOut : MonoBehaviour
{
    [SerializeField] Inventory inventory;
    [SerializeField] GameObject whatToSpawn;
    [SerializeField] string WhatToTrade;
    [SerializeField] GameObject boulder;
    int choosenSlot = -1;
    SpriteRenderer render;
    EdgeCollider2D coll;
    bool isThereAShkatulka = false;
    private void Start()
    {
        render = boulder.GetComponent<SpriteRenderer>();
        coll = boulder.GetComponent<EdgeCollider2D>();
    }
    private void OnMouseDown()
    {
        choosenSlot = -1;
        isThereAShkatulka = false;
        for (int i = 0; i < inventory.isChosen.Length; i++)
        {
            if (inventory.isChosen[i])
            {
                choosenSlot = i;

            }
            if (inventory.isFull[i] == true && (inventory.slots[i].transform.GetChild(0).gameObject.name == WhatToTrade + "(Clone)"))
            {

                isThereAShkatulka = true;
            }
        }
        if (isThereAShkatulka && choosenSlot != -1 && inventory.isFull[choosenSlot] == true)
        {
            if (inventory.slots[choosenSlot].transform.GetChild(0).gameObject.name == WhatToTrade + "(Clone)")
            {
                inventory.slots[choosenSlot].GetComponent<Slot>().SlotDropped(choosenSlot);
                render.enabled = false;
                coll.enabled = false;
            }
        }
        else if (!isThereAShkatulka)
        {
            for (int i = 0; i < inventory.slots.Length; i++)
            {
                if (inventory.isFull[i] == false)
                {
                    render.enabled = true;
                    coll.enabled = true;
                    inventory.isFull[i] = true;
                    Instantiate(whatToSpawn, inventory.slots[i].transform);
                    break;
                }
            }
        }
    }
}
