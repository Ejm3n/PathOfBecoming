using UnityEngine;
using VectorUtils;
using AnimationUtils.RenderUtils;

public class Segment : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    [SerializeField] Transform rayPoint;
    [SerializeField] Sprite[] segmentSprites;
    [SerializeField] Sprite[] segmentSpritesHighlighted;

    public bool connected { get; private set; }
    public bool highlighted { get; private set; }

    float fadeTime = 0.5f;
    public int type { get; private set; }

    private void Awake()
    {
        spriteRenderer.Unfade(fadeTime);
        connected = false;
        highlighted = false;
    }

    public void Initialize()
    {
        Segment adjacentSegment = Search_Adjacent_Segments();
        if (adjacentSegment)
            type = adjacentSegment.type;
        else
            type = Random.Range(0, segmentSprites.Length);
        spriteRenderer.sprite = segmentSprites[type];
    }

    Segment Search_Adjacent_Segments()
    {
        LayerMask segmentsLM = LayerMask.GetMask("PuzzleSegment");
        RaycastHit2D hit = Physics2D.Raycast(rayPoint.position, Vector2.up.Turn(gameObject.transform.rotation.eulerAngles.z), 1, segmentsLM);
        if (hit)
            return hit.collider.GetComponent<Segment>();
        else
            return null;
    }

    public bool Connect_Adjacent_Segments()
    {
        bool connectAdjacent;
        bool highlight;
        Segment adjacentSegment = Search_Adjacent_Segments();
        if (adjacentSegment && adjacentSegment.type != type) //adjacent segment is not the same
        {
            connectAdjacent = false;
            highlight = false;
        }
        else if (adjacentSegment && adjacentSegment.type == type) //adjacent segment is the same
        {
            connectAdjacent = true;
            highlight = true;
        }
        else //no adjacent segment
        {
            connectAdjacent = true;
            highlight = false;
        }

        if (highlight != highlighted)
        {
            //spriteRenderer.transform.SpringRotation(0.5f, Vector3.forward * 45);
            spriteRenderer.sprite = highlight ? segmentSpritesHighlighted[type] : segmentSprites[type];
            highlighted = highlight;
        }
        if (adjacentSegment && highlight != adjacentSegment.highlighted)
        {
            //adjacentSegment.spriteRenderer.transform.SpringRotation(0.5f, Vector3.forward * 45);
            adjacentSegment.spriteRenderer.sprite = highlight ? segmentSpritesHighlighted[adjacentSegment.type] : segmentSprites[adjacentSegment.type];
            adjacentSegment.highlighted = highlight;
        }

        connected = connectAdjacent;
        return connected;
    }
}
