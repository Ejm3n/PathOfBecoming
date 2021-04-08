using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryTurnOn : MonoBehaviour
{
    [SerializeField] GameObject[] WhatToTurnOff;
    [SerializeField] Animator panelAnim;
    private void OnEnable()
    {
        StartCoroutine(TurnOffCanvases());
    }
    private IEnumerator TurnOffCanvases()
    {
        while(panelAnim.GetBool("PanelShow"))
        {
            yield return null;
        }
        if (!panelAnim.GetBool("PanelShow"))
        {
            SwitchSetActive(false);
            yield return new WaitForSeconds(5);
            SwitchSetActive(true);
        }    
        yield break;
    }
    private void SwitchSetActive(bool WhatToSwitch)
    {
        for (int i = 0; i < WhatToTurnOff.Length; i++)
        {
            WhatToTurnOff[i].SetActive(WhatToSwitch);
        }
    }

}
