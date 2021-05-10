using System.Collections;
using UnityEngine;
using GlobalVariables.PuzzleVariables;

public class Spawner : MonoBehaviour
{
    float spawnDelay = 0.5f;

    private void Start()
    {
        StartCoroutine(Spawn_Hexagons());
    }

    IEnumerator Spawn_Hexagons()
    {
        GameObject centralHex = Instantiate(Prefabs.HEXAGONPREFAB, gameObject.transform);
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
            Instantiate(Prefabs.HEXAGONPREFAB, (center - centralHexCol.bounds.center) * 2.1f, Quaternion.identity, gameObject.transform);
        }
    }

    float Avg(params float[] values)
    {
        float result = 0;
        for (int i=0; i< values.Length; i++)
            result += values[i];
        return result / values.Length;
    }
}
