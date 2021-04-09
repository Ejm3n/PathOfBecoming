using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManaCounter : MonoBehaviour
{
    [SerializeField] float startMana;
    public float currentMana;
    private Image manaBar;
    [SerializeField] float howMuchManaPerSec;
    private float timerTillTick = 1f;
    private void Start()
    {
       manaBar =  gameObject.GetComponent<Image>();
        currentMana = startMana;
    }
    private void Update()
    {
        if (currentMana < 100 )
        {
            timerTillTick -= Time.deltaTime;
            if(timerTillTick<=0)
            {
                currentMana += howMuchManaPerSec;
                if (currentMana > 100)
                    currentMana = 100;
                manaBar.fillAmount = currentMana / startMana;
                timerTillTick = 1;
            }
           
        }
       
        
        
    }
    public void SpellShot(float manaCost)
    {
        currentMana -= manaCost;
        manaBar.fillAmount = currentMana / startMana;
    }
}
