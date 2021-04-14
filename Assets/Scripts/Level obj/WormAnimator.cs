using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WormAnimator : MonoBehaviour
{
    [SerializeField] Animator anim;
    [SerializeField] GameObject nextDia;
    [SerializeField] string anim1;
    [SerializeField] string anim2;
    [SerializeField] string anim3;
    //int animatorInt = 0;
   [SerializeField] float animLen1;
    [SerializeField]float animLen2;

    private void OnEnable()
    {
        StartCoroutine(PlayClips());
    }
    private IEnumerator PlayClips()
    {
        anim.Play(anim1);
        yield return new WaitForSeconds(animLen1);
        anim.Play(anim2);
        yield return new WaitForSeconds(animLen2);
        anim.Play(anim3);
        nextDia.SetActive(true);
        yield break;
    }
} 
