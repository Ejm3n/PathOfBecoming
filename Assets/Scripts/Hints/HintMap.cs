using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HintMap : MonoBehaviour
{
    public ParticleSystem hintParticle;
    public List<HintHighlight> map;

    ParticleSystem.ShapeModule particleShape;

    Coroutine hintCoroutine;

    public bool highlighted { get; private set; }

    private void Awake()
    {
        if (map.Count > 0)
        {
            highlighted = false;
            particleShape = hintParticle.shape;
            particleShape.spriteRenderer = map[0].objectToHighlight;
        }
    }

    public void Highlight()
    {
        if (map.Count == 0)
            return;
        if (!highlighted)
            hintCoroutine = StartCoroutine(Highlight_With_Delay());
    }

    public void Stop_Highlight()
    {
        highlighted = false;
        StopCoroutine(hintCoroutine);
        hintParticle.Stop();
        map.RemoveAt(0);
    }

    IEnumerator Highlight_With_Delay()
    {
        highlighted = true;
        particleShape.spriteRenderer = map[0].objectToHighlight;
        yield return new WaitForSeconds(map[0].highlightDelay);
        hintParticle.Play();
    }
}
