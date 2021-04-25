using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateFewThingsIfTapped : MonoBehaviour
{
    ///
    /// просто активатор объектов если нажат
    ///
    [SerializeField] GameObject[] whatActivate;
    private void OnMouseDown()
    {
        for(int i = 0; i<whatActivate.Length;i++)
        {
            if(whatActivate[i] != null)
            {
                whatActivate[i].SetActive(true);
            }          
        }
        Destroy(gameObject);
    }
}
