using System.Collections;
using System;
using UnityEngine;

public class Hassle : MonoBehaviour
{
    [SerializeField] private Material _material;

    private void Awake()
    {
        _material.SetFloat("_Fade", 1);
    }

    public void Hassle_Disappear(float procTime)
    {
        StartCoroutine(Hassle_Proc(1f, 0f, procTime, () => gameObject.SetActive(false)));
    }

    public void Hassle_Appear(float procTime)
    {
        gameObject.SetActive(true);
        StartCoroutine(Hassle_Proc(0f, 1f, procTime));
    }

    IEnumerator Hassle_Proc(float fadeFrom, float fadeTo, float procTime, Action onComplete = null)
    {
        float iter = (fadeTo - fadeFrom) / procTime;
        float currentFade = fadeFrom;
        while (Mathf.Abs(fadeTo - currentFade) > 0.001f)
        {
            currentFade += iter * Time.deltaTime;
            currentFade = Mathf.Clamp(currentFade, 0, 1);
            _material.SetFloat("_Fade", currentFade);
            yield return null;
        }
        onComplete?.Invoke();
    }
}
