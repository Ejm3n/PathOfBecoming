using UnityEngine;
using GlobalVariables.PuzzleVariables;

public class MouseChip : CatChip
{
    [SerializeField] SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer.sprite = Sprites.MICESPRITES[Random.Range(0, Sprites.MICESPRITES.Length)];
    }

    public override void Move(Vector3 target, int[] index)
    {
        Move(target, index, typeof(CatChip));
    }
}
