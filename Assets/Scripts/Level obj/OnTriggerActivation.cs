using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTriggerActivation : MonoBehaviour
{
    [Header ("СМОТРИТЕ ВНИМАТЕЛЬНО НА ЛЭЕР ОБЪЕКТА")]
    [SerializeField] private GameObject objectToActivate;
    [SerializeField] private Transform spawnPosition;
    private bool isActivated = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!isActivated)
        {
            objectToActivate.SetActive(true);
            isActivated = true;
        }
    }
    public void RestoreTrigger()
    {
        if(!objectToActivate.activeInHierarchy)
        {
            objectToActivate.transform.position = spawnPosition.position;
            objectToActivate.SetActive(false);
        }     
        isActivated = false;
    }
}
