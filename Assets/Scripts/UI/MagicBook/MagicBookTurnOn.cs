using System.Collections;
using UnityEngine;

public class MagicBookTurnOn : MonoBehaviour
{
    [SerializeField] GameObject[] WhatToTurnOff;//список объектов которые надо отключить
    [SerializeField] Animator panelAnim;//анимация панели диавлогов
    [SerializeField] DialogueSystem ds;//ссылка на диалоговую систему
    [SerializeField] GameObject firstSpell;//так как у меня стрельба не удаляет а отключает магические пули то я просто спрошу активирована ли первая пуля
    private void OnEnable()
    {
        ds.canUseSpellBook = true;
        StartCoroutine(TurnOffCanvases());// при включении вызываем корутину
    }
    private IEnumerator TurnOffCanvases()
    {
        while (panelAnim.GetBool("PanelShow")) //пока диалоги не закрыты мы ничего не делаем
        {
            yield return null;
        }
        if (!panelAnim.GetBool("PanelShow"))//когда диалоги закрыты мы показываем до тех пор пока на сцене не будет обнаружен геймобжект спелл и выключаем обратно
        {
            SwitchSetActive(false);
            while (!firstSpell.activeInHierarchy)
            {
                yield return null;
            }
            Debug.Log("нашел геймобжект active in hie");
            yield return new WaitForSeconds(2);
            SwitchSetActive(true);
            yield break;
        }
        
        
    }
    private void SwitchSetActive(bool WhatToSwitch)//вырубаем и врубаем элементы указанные в массиве геймобжектов
    {
        for (int i = 0; i < WhatToTurnOff.Length; i++)
        {
            if (WhatToTurnOff[i] != null)
                WhatToTurnOff[i].SetActive(WhatToSwitch);
        }
    }

}