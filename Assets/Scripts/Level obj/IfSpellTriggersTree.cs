using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IfSpellTriggersTree : MonoBehaviour
{
    [SerializeField] GameObject[] whatToActivate;
    [SerializeField] GameObject[] whatToDeactivate;
    [SerializeField] FixedJoint2D joint;
    [SerializeField] string spellName;
    [SerializeField] float timeToWait;
    [SerializeField] HintMap hintMap;
    public bool Avalible;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == spellName && Avalible)
        {
            collision.gameObject.SetActive(false);
            joint.enabled = false;
            StartCoroutine(activateDelay());
            hintMap.Stop_Highlight();
        }
    }
    private IEnumerator activateDelay()
    {
        yield return new WaitForSeconds(timeToWait);
        for (int i = 0; i < whatToActivate.Length; i++)
        {
            whatToActivate[i].SetActive(true);
        }
        for (int i = 0; i < whatToDeactivate.Length; i++)
        {
            whatToDeactivate[i].SetActive(false);
        }
        gameObject.SetActive(false);
    }
}