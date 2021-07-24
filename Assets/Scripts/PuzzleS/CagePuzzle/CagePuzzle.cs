using System.Collections;
using UnityEngine;
using GlobalVariables.PuzzleVariables;
using System.Collections.Generic;

public class CagePuzzle : Puzzle
{
    float spawnDelay = 0.5f;
    public bool activated { get; private set; }

    List<Hexagon> hexagons = new List<Hexagon>();

    private void Start()
    {
        activated = false;
        StartCoroutine(Spawn_Hexagons());
    }

    public void Check_Win_Condition()
    {
        bool winCondition = true;
        for (int i = 0; i < hexagons.Count; i++)
        {
            hexagons[i].Check_Segments_Connection();
            if (!hexagons[i].connected)
                winCondition = false;
        }
        if(winCondition)
            Solve_Puzzle();
    }

    IEnumerator Spawn_Hexagons()
    {
        GameObject centralHex = Instantiate(Prefabs.HEXAGONPREFAB, gameObject.transform);
        hexagons.Add(centralHex.GetComponent<Hexagon>());
        PolygonCollider2D centralHexCol = centralHex.GetComponent<PolygonCollider2D>();
        Vector3[] edgeCenters = new Vector3[centralHexCol.points.Length];
        Vector3 edgeCenter;

        for (int i = 0; i < centralHexCol.points.Length; i++)
        {
            if (i == centralHexCol.points.Length - 1)
                edgeCenter = new Vector3(Avg(centralHexCol.points[0].x, centralHexCol.points[i].x), Avg(centralHexCol.points[0].y, centralHexCol.points[i].y));
            else
                edgeCenter = new Vector3(Avg(centralHexCol.points[i].x, centralHexCol.points[i + 1].x), Avg(centralHexCol.points[i].y, centralHexCol.points[i + 1].y));
            edgeCenters[i] = edgeCenter;
        }

        foreach (Vector3 center in edgeCenters)
        {
            yield return new WaitForSeconds(spawnDelay);
            hexagons.Add(Instantiate(Prefabs.HEXAGONPREFAB, center * 2.1f + transform.position, Quaternion.identity, gameObject.transform).GetComponent<Hexagon>());
        }

        yield return new WaitUntil(() => hexagons[hexagons.Count - 1].ready);
        for (int i = 0; i < hexagons.Count; i++)
            hexagons[i].Rotate_Hex(2);
        SoundRecorder.Play_Effect(Sounds.RIDDLESOUND);
        activated = true;
    }

    float Avg(params float[] values)
    {
        float result = 0;
        for (int i=0; i< values.Length; i++)
            result += values[i];
        return result / values.Length;
    }
}
