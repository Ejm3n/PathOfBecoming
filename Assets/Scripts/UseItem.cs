using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseItem : MonoBehaviour
{
    [SerializeField] GameObject inventory;
    [SerializeField] GameObject[] triggersToActivate;
    [SerializeField] string usableItem;
    private int chosen = -1;
    private void OnMouseDown()
    {
        var inv = inventory.GetComponent<Inventory>();
        for (int i = 0;i< inv.isChosen.Length; i++)
        {
            if(inv.isChosen[i] == true)
            {
                chosen = i;
            }
        }
        if(chosen!=-1)
        {
            if(inv.slots[chosen].transform.Find("Spider").gameObject)
            {
                for(int i = 0; i<triggersToActivate.Length;i++)
                {
                    triggersToActivate[i].SetActive(true);
                }
            }
            Destroy(gameObject);
        }
    }
}
