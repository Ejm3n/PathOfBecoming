using System.Collections;
using UnityEngine;

public class InventoryTurnOn : MonoBehaviour
{
    [SerializeField] GameObject[] WhatToTurnOff;//список объектов которые надо отключить
    [SerializeField] Animator panelAnim;//анимация панели диавлогов
    [SerializeField] DialogueSystem ds;//ссылка на диалоговую систему
    [SerializeField] GameObject inv;
    [SerializeField] CanvasGroup invCG;
    //[SerializeField] GameObject interactWithSpider;
    public void InventoryGuide()
    {
        inv.SetActive(true);
        ds.canUseInventory = true;
        StartCoroutine(TurnOffCanvases());// при включении вызываем корутину
    }
    private IEnumerator TurnOffCanvases()
    {
        while(panelAnim.GetBool("PanelShow")) //пока диалоги не закрыты мы ничего не делаем
        {
            yield return null;
        }
        if (!panelAnim.GetBool("PanelShow"))//когда диалоги закрыты мы показываем инвентарь на 5 секунд и выключаем обратно
        {
            invCG.alpha = 1;
            invCG.blocksRaycasts = true;
            invCG.interactable = true;
            SwitchSetActive(false);
            yield return new WaitForSeconds(2);         
            SwitchSetActive(true);
        }
        yield break;
    }
    private void SwitchSetActive(bool WhatToSwitch)//вырубаем и врубаем элементы указанные в массиве геймобжектов
    {
        for (int i = 0; i < WhatToTurnOff.Length; i++)
        {
            if(WhatToTurnOff[i] != null)
                WhatToTurnOff[i].SetActive(WhatToSwitch);
        }       
    }

}
