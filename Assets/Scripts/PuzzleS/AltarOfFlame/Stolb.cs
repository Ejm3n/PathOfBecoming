using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stolb : MonoBehaviour
{
    [SerializeField] Block[] blocks;
    BlockPuzzle bp;
    public bool fullStolb = false;
    public bool clickable = true;
    private void Awake()
    {
        bp = GetComponentInParent<BlockPuzzle>();
    }
    private void OnMouseDown()
    {
        if(!blocks[blocks.Length-1].isFilled && clickable)
        {
            for (int i = 0; i < blocks.Length; i++)
            {
                if (!blocks[i].isFilled)
                {                   
                    bp.CurrentMana = blocks[i].FillBlock(bp.CurrentMana);                    
                    break;
                }
            }
        }

        if(blocks[blocks.Length - 1].isFilled)
        {
            fullStolb = true;
        }    
    }
    public void ResetBlocks()
    {
        fullStolb = false;
        foreach(Block block in blocks)
        {
            block.EmptyBlock();
        }
    }
    public void StartRazlom(Block whereRazlom)
    {
            bp.DoRazlom(whereRazlom.StolbToFill);       
    }
    public void AddRazlomPower(int power)
    {
        if (!blocks[blocks.Length - 1].isFilled)
        {
            for (int i = 0; i < blocks.Length; i++)
            {
                if (!blocks[i].isFilled)
                {
                    if (blocks[i].gameObject.GetComponent<BlackBlock>() != null)
                        power = power * 2;
                    blocks[i].PartFillBlock(power);
                    break;
                }
            }
        }
        if (blocks[blocks.Length - 1].isFilled)
        {
            fullStolb = true;
        }
    }    
}
