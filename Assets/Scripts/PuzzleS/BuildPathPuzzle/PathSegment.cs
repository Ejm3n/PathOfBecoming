using UnityEngine;
using AnimationUtils.TransformUtils;
using System;

public class PathSegment : MonoBehaviour
{
    public float rangeX { get; private set; }
    public float rangeY { get; private set; }
    public int index { get; private set; }

    const float offset = 0.5f;

    static PathSegment selected;

    SpriteRenderer path;

    Vector3 notChosenPos;
    Vector3 chosenPos;

    private void Awake()
    {
        BoxCollider2D coll = GetComponent<BoxCollider2D>();
        path = GetComponent<SpriteRenderer>();
        rangeX = Mathf.Abs(coll.bounds.max.x - coll.bounds.min.x);
        rangeY = Mathf.Abs(coll.bounds.max.y - coll.bounds.min.y);
    }

    public void Initialise(int index, Sprite pathSprite, bool original, Vector3 startPosition)
    {
        this.index = index;
        path.sprite = pathSprite;
        path.flipX = !original;

        transform.position = startPosition;
        notChosenPos = transform.position;
        chosenPos = transform.position;
        chosenPos.y += offset;
    }

    public void Select()
    {
        if (selected != null)
            selected.Cancel_Selection();
        transform.Move_To(chosenPos, 0.5f, false);
        selected = this;
    }

    public void Cancel_Selection()
    {
        transform.Move_To(notChosenPos, 0.5f, false);
    }

    public void Choose(Vector3 moveTo, Action wincon)
    {
        transform.Move_To(moveTo, 0.5f, false, wincon);
        selected = null;
    }
}
