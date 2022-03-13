using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeschernikSpawner : MonoBehaviour
{
    public Peschernik[] Pescherniks;
    public bool IsActivated;
    public void SetDefaultPositions()
    {
        if(IsActivated)
        {
            foreach (Peschernik p in Pescherniks)
            {
                p.gameObject.SetActive(true);
                p.SetDefaultPosition();
            }
        }
        
    }
    public void ActivateSpawn()
    {
        IsActivated = true;

    }
}
