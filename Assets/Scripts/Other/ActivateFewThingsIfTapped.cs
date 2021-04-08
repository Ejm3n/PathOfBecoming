using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateFewThingsIfTapped : MonoBehaviour
{
    [SerializeField] GameObject[] whatActivate;
    private void OnMouseDown()
    {
        for(int i = 0; i<whatActivate.Length;i++)
        {
            whatActivate[i].SetActive(true);
        }
    }
}
