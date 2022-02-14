using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OntriggerRestorer : MonoBehaviour
{
    [SerializeField] private OnTriggerActivation trigger;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        trigger.RestoreTrigger();
    }
}
