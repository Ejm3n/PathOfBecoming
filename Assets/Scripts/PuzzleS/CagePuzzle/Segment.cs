using UnityEngine;
using GlobalVariables.PuzzleVariables;
using VectorUtils;
using AnimationUtils.RenderUtils;

public class Segment : MonoBehaviour
{
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] Transform rayPoint;

    float fadeTime = 0.5f;
    public int type { get; private set; }

    private void Awake()
    {
        spriteRenderer.Unfade(fadeTime);
    }

    public void Initialize()
    {
        int adjacentType = Search_Adjacent_Segments();
        if (adjacentType > -1)
            type = adjacentType;
        else
            type = Random.Range(0, Sprites.SEGMENTSPRITES.Length);
        spriteRenderer.sprite = Sprites.SEGMENTSPRITES[type];
    }

    int Search_Adjacent_Segments()
    {
        RaycastHit2D hit = Physics2D.Raycast(rayPoint.position, Vector2.up.Turn(gameObject.transform.rotation.eulerAngles.z), 1, Layers.PUZZLESEGMENTLM);
        if (hit)
            return hit.collider.GetComponent<Segment>().type;
        else
            return -1;
    }
}
