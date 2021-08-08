using UnityEngine;
using AnimationUtils.RenderUtils;
using AnimationUtils.TransformUtils;

public class Hexagon : MonoBehaviour
{
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] GameObject segmentPrefab;
    CagePuzzle controller;
    Segment[] segments;

    public bool ready { get; private set; }

    public bool connected { get; private set; }

    float fadeTime = 0.5f;

    void Awake()
    {
        controller = transform.parent.gameObject.GetComponent<CagePuzzle>();
        spriteRenderer.Unfade(fadeTime, () => ready = true);
        Initialize();
    }

    public void Initialize()
    {
        int segmentsAmount = 6;
        segments = new Segment[segmentsAmount];
        float degree = 360 / segmentsAmount;
        for (int i = 0; i < segmentsAmount; i ++)
        {
            segments[i] = Instantiate(segmentPrefab, gameObject.transform).GetComponent<Segment>();
            segments[i].gameObject.transform.Rotate(0, 0, i * degree);
            segments[i].Initialize();
        }
    }

    private void OnMouseDown()
    {
        if (controller.activated)
            Rotate_Hex(60, 0.5f);
    }

    void Rotate_Hex(float angleDeg, float timeToRotate)
    {
        transform.SpringRotation(timeToRotate, Vector3.forward * angleDeg, controller.Check_Win_Condition);
    }

    public void Rotate_Hex(float timeToRotate = 0.5f)
    {
        float angle = Random.Range(1, 6) * 60;
        transform.SpringRotation(timeToRotate, Vector3.forward * angle, controller.Check_Win_Condition);
    }

    public void Check_Segments_Connection()
    {
        bool hexConnected = true;
        foreach(Segment segment in segments)
            if (!segment.Connect_Adjacent_Segments())
                hexConnected = false;
        connected = hexConnected;
    }
}
