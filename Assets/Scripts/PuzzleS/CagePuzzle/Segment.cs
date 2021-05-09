using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GlobalVariables.PuzzleVariables;

public class Segment : MonoBehaviour
{
    [SerializeField] SpriteRenderer spriteRenderer;
    
    int type;

    public void Initialize(int type)
    {
        this.type = type;
        spriteRenderer.sprite = Sprites.SEGMENTSPRITES[type];
    }
}
