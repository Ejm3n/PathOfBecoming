using GlobalVariables.PuzzleVariables;
using UnityEngine;
using AnimationUtils.RenderUtils;
using AnimationUtils.TransformUtils;

public class Hexagon : MonoBehaviour
{
    [SerializeField] SpriteRenderer spriteRenderer;
    Segment[] segments;

    float fadeTime = 0.5f;

    void Awake()
    {
        spriteRenderer.Unfade(fadeTime);
        Initialize();
    }

    public void Initialize()
    {
        int segmentsAmount = 6;
        segments = new Segment[segmentsAmount];
        float degree = 360 / segmentsAmount;
        for (int i = 0; i < segmentsAmount; i ++)
        {
            segments[i] = Instantiate(Prefabs.SEGMENTPREFAB, gameObject.transform).GetComponent<Segment>();
            segments[i].gameObject.transform.Rotate(0, 0, i * degree);
            segments[i].Initialize();
        }
    }

    private void OnMouseDown()
    {
        transform.SpringRotation(0.5f, Vector3.forward * 60);
    }
}
