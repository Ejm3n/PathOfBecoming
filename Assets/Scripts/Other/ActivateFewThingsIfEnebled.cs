using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateFewThingsIfEnebled : MonoBehaviour
///
/// просто активатор объектов если включен
///

{
    [SerializeField] GameObject[] whatActivate;
    private void OnEnable()
    {
        for (int i = 0; i < whatActivate.Length; i++)
        {
            if (whatActivate[i] != null)
            {
                whatActivate[i].SetActive(true);
            }
        }
        Destroy(gameObject);
    }
}
