using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anchutka : MonoBehaviour
{
    [SerializeField] GameObject[] whatToActivate;
    [SerializeField] GameObject[] whatToDeactivate;
    [SerializeField] Animator anim;
    [SerializeField] string animationName;
    [SerializeField] float animLength;
    private void OnEnable()
    {
        anim.Play(animationName);
        StartCoroutine(activateDelay());
    }
    private IEnumerator activateDelay()
    {
        yield return new WaitForSeconds(animLength);
        for (int i = 0; i < whatToActivate.Length; i++)
        {
            whatToActivate[i].SetActive(true);
        }
        for (int i = 0; i < whatToDeactivate.Length; i++)
        {
            whatToDeactivate[i].SetActive(false);
        }
        yield break;
    }
}
