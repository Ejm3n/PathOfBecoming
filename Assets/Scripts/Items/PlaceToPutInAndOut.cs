using UnityEngine;
using Cinemachine;
using AnimationUtils.RenderUtils;
public class PlaceToPutInAndOut : InteractEvent
{
    [SerializeField] GameObject canvas;
    [SerializeField] Inventory inventory;
    [SerializeField] GameObject whatToSpawn;//шкатулка что заспавнится в инвентаре
    [SerializeField] string WhatToTrade;
    [SerializeField] SpriteRenderer boulder;
    [SerializeField] GameObject inGameShkat;
    [SerializeField] CinemachineVirtualCamera rockCamera;
    [SerializeField] DialogueSystem ds;
    [SerializeField] HintMap hintMap;
    int choosenSlot = -1;
    bool isThereAShkatulka = false;

    public override void Start_Event()
    {
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
        if (hintMap.map[0].objectToHighlight.name == "MagicAltar_0")
            hintMap.Stop_Highlight();
    }
    private void ChangeImage(bool what)
    {
        ds.SetUI(false);
        rockCamera.Priority = 11;
        inGameShkat.SetActive(!what);
        Animate_Boulder(what);
    }

    void Return_Control(bool appear)
    {
        rockCamera.Priority = 1;
        boulder.gameObject.SetActive(appear);
        ds.SetUI(true);
    }

    void Animate_Boulder(bool appear, float timeToAnimate = 3f)
    {
        if (appear)
        {
            boulder.gameObject.SetActive(true);
            boulder.Unfade(timeToAnimate, () => Return_Control(appear));
        }
        else
            boulder.Fade(timeToAnimate, () => Return_Control(appear));
    }
}
