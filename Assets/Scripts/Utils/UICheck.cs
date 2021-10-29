using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UICheck : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public static bool overUI;
    public void OnPointerEnter(PointerEventData eventData)
    {
        overUI = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        overUI = false;
    }
}
