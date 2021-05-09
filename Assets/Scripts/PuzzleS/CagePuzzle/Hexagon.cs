using GlobalVariables.PuzzleVariables;
using UnityEngine;

public class Hexagon : MonoBehaviour
{
    PolygonCollider2D hexagon;
    Segment[] segments;

    void Awake()
    {
        hexagon = GetComponent<PolygonCollider2D>();
        Initialize(6);
    }

    public void Initialize(int segmentsAmount)
    {
        segments = new Segment[segmentsAmount];
        float degree = 360 / segmentsAmount;
        for (int i = 0; i < segmentsAmount; i ++)
        {
            segments[i] = Instantiate(Prefabs.SEGMENTPREFAB, gameObject.transform).GetComponent<Segment>();
            segments[i].Initialize(Random.Range(0, Sprites.SEGMENTSPRITES.Length));
            segments[i].gameObject.transform.Rotate(0, 0, i * degree);
        }
    }


}
