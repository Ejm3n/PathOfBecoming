using System;
using UnityEngine;
using UnityEngine.UI;

public class Flower : MonoBehaviour
{
    Image hpImage;
    [HideInInspector] public Text countText;
    Inventory inventory;
    [HideInInspector] public int SlotNum;
    private void Start()
    {
        hpImage =  GameObject.FindGameObjectWithTag("Hp").GetComponent<Image>();
        countText = GetComponentInChildren<Text>();
        inventory = FindObjectOfType<Inventory>();  
    }
    public void OnFlowerClick()
    {
        if(hpImage.fillAmount!=1)
        {
            int count = Convert.ToInt32(countText.text);
            hpImage.fillAmount += 0.25f;
            if (count>1)
            {
                count--;
                countText.text = count.ToString();
            }
            else if(count == 1)
            {
                inventory.SlotDropped(SlotNum);
                Destroy(gameObject);
            }          
        }
    }
}
