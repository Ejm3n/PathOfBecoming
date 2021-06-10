using UnityEngine;
using UnityEngine.Events;

public class AltarInteraction : InteractEvent
{
   //public GameObject puzzle;
    [SerializeField] bool create;
    public UnityEvent winEvent;
    public UnityEvent closeEvent;

    [SerializeField] DialogueSystem ds;


    [SerializeField] Inventory inventory;
    [SerializeField] GameObject[] whatToActivate;
    [SerializeField] string WhatNotToTrade;
    int currentActivation = 0;
    int choosenSlot = -1;
    int stage = 0;
   
    [SerializeField] GameObject whatToSpawn;
    [SerializeField] string WhatToTrade;
    [SerializeField] GameObject[] whatActivate;
    [SerializeField] GameObject[] whatDeactivate;
    bool EndOf2Interaction = false;

    [SerializeField] GameObject boulder;
    [SerializeField] GameObject whatNextToSpawn;
    [SerializeField] GameObject inGameShkat;
    bool isThereAShkatulka = false;

    public override void Start_Event()
    {
        for (int i = 0; i < inventory.isChosen.Length; i++)//смотрим какой слот выбран
        {
            if (inventory.isChosen[i])
            {
                choosenSlot = i;
                break;
            }
        }
        if (inventory.slots[choosenSlot].transform.GetChild(0) != null && choosenSlot != -1 && inventory.slots[choosenSlot].transform.GetChild(0).gameObject.name == WhatNotToTrade + "(Clone)")
        {

            if (currentActivation < whatToActivate.Length)//включаем один из диалогов в случае неправильной постановки предмета
            {
                whatToActivate[currentActivation].SetActive(true);
                currentActivation++;
            }
            else//если иалоги заканчиваются то больше ниче говорить не надо и уничтожаем геймобжект
            {
                //Destroy(gameObject);
                
            }
        }
        if (choosenSlot != -1 && inventory.slots[choosenSlot].transform.GetChild(0).gameObject.name == WhatToTrade + "(Clone)" && !EndOf2Interaction)//прлверка если выбран нужный предмет
        {
            inventory.SlotDropped(choosenSlot);
            for (int i = 0; i < inventory.slots.Length; i++)
            {
                if (inventory.isFull[i] == false)//создаем в пустом слоте предмет
                {
                    inventory.isFull[i] = true;
                    Instantiate(whatToSpawn, inventory.slots[i].transform);
                    for (int k = 0; k < whatActivate.Length; k++)
                    {
                        if (whatActivate[k] != null)
                        {
                            whatActivate[k].SetActive(true);
                        }

                    }
                    for (int k = 0; k < whatDeactivate.Length; k++)//отключаем ненужные объекты
                    {
                        if (whatDeactivate[k] != null)
                        {
                            whatDeactivate[k].SetActive(false);
                        }
                    }
                    EndOf2Interaction = true;
                    break;
                }
            }
        }
        choosenSlot = -1;
        isThereAShkatulka = false;
        for (int i = 0; i < inventory.isChosen.Length; i++)//узнаем какой слот выбрат и есть ли шкатулка
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
        if (isThereAShkatulka && choosenSlot != -1 && inventory.isFull[choosenSlot] == true)//если есть шкатулка и инвентарь полон и выбран нужный слот
        {
            if (inventory.slots[choosenSlot].transform.GetChild(0).gameObject.name == WhatToTrade + "(Clone)")//спавним камень и шкатулку непосредственно в игре
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
        boulder.SetActive(what);
        inGameShkat.SetActive(!what);
    }
}
