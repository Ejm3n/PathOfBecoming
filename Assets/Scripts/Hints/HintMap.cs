using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]
public class HintMap : MonoBehaviour
{
    [SerializeField] List<HintHighlight> map;

    ParticleSystem hintParticle;
    ParticleSystem.ShapeModule particleShape;

    Coroutine hintCoroutine;

    public bool highlighted { get; private set; }

    private void Awake()
    {
        hintParticle = GetComponent<ParticleSystem>();
        highlighted = false;
        if (map.Count > 0)
        {
            particleShape = hintParticle.shape;
            particleShape.spriteRenderer = map[0].objectToHighlight;
        }
    }

    public void Highlight(int id)
    {
        if (map.Count <= id)
            return;
        if (highlighted)
            Stop_Highlight();
        hintCoroutine = StartCoroutine(Highlight_With_Delay(id));
    }

    public void Stop_Highlight()
    {
        if (!highlighted)
            return;
        highlighted = false;
        StopCoroutine(hintCoroutine);
        hintParticle.Stop();
    }

    IEnumerator Highlight_With_Delay(int id)
    {
        highlighted = true;
        particleShape.spriteRenderer = map[id].objectToHighlight;
        yield return new WaitForSeconds(map[id].highlightDelay);
        hintParticle.Play();
    }
}
