using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Notes : MonoBehaviour
{
   // [SerializeField] CanvasGroup CG;
   // int clicked = -1;
    //bool click = false;
    public void OnClick()
    {
       
        //clicked *= -1;
        //click = !click;
        //CG.alpha = clicked;
        //CG.interactable = click;
        //CG.blocksRaycasts = click;
       var notes = GameObject.FindGameObjectWithTag("Notes").GetComponent<CanvasGroup>();
        notes.alpha = 1;
        notes.interactable = true;
        notes.blocksRaycasts = true;
    }
}
