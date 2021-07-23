using UnityEngine;

public class MouseChip : CatChip
{
    [SerializeField] SpriteRenderer spriteRenderer;

    public void Initialise(Sprite sprite)
    {
        spriteRenderer.sprite = sprite;
    }

    public override void Move(Vector3 target, int[] index)
    {
        Move(target, index, typeof(CatChip));
    }
}
