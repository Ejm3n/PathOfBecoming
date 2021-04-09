using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IfObjectCollidesWithSpell : MonoBehaviour
{
    [SerializeField] GameObject[] whatToActivate;
    [SerializeField] GameObject[] whatToDeactivate;
    [SerializeField] Animator anim;
    [SerializeField] Animation an;
    [SerializeField] string spellName;
    [SerializeField] string animationName;
    [SerializeField] float animLength;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == spellName + "(Clone)")
        {
            collision.gameObject.SetActive(false);
            anim.Play(animationName);
            StartCoroutine(activateDelay());
        }
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
    }
}
