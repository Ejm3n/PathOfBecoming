using UnityEngine;

public class PlaceToPutInAndOut : MonoBehaviour
{
    [SerializeField] Inventory inventory;
    [SerializeField] GameObject whatToSpawn;
    [SerializeField] string WhatToTrade;
    [SerializeField] GameObject boulder;
    [SerializeField] GameObject inGameShkat;
    int choosenSlot = -1;
    SpriteRenderer Brender;
    EdgeCollider2D Bcoll;

    bool isThereAShkatulka = false;
    private void Start()
    {
        Brender = boulder.GetComponent<SpriteRenderer>();
        Bcoll = boulder.GetComponent<EdgeCollider2D>();
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
                inventory.SlotDropped(choosenSlot);
                ChangeImage(false);
            }
        }
        else if (!isThereAShkatulka)
        {
            for (int i = 0; i < inventory.slots.Length; i++)
            {
                if (inventory.isFull[i] == false)
                {
                    ChangeImage(true);
                    inventory.isFull[i] = true;
                    Instantiate(whatToSpawn, inventory.slots[i].transform);
                    break;
                }
            }
        }
    }
    private void ChangeImage(bool what)
    {
        Brender.enabled = what;
        Bcoll.enabled = what;
        inGameShkat.SetActive(!what);
    }
}
