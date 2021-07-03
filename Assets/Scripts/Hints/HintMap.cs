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

    public void Set_Map(HintHighlight[] hints)
    {
        if (highlighted)
            Stop_Highlight();
        map = new List<HintHighlight>();
        map.AddRange(hints);
    }

    public HintHighlight[] Get_Map()
    {
        HintHighlight[] currentMap = new HintHighlight[map.Count];
        for (int i = 0; i < currentMap.Length; i++)
            currentMap[i] = map[i];
        return currentMap;
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
