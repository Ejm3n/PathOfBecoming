using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackBlock : Block
{
    [SerializeField] Block[] cancellingBlocks;
    BlockPuzzle bp;
    bool isStealingMana = false;
    private void Awake()
    {
        bp = FindObjectOfType<BlockPuzzle>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!isFilled && !isStealingMana)
        {
            foreach (Block block in cancellingBlocks)
            {
                if(block.isFilled)
                {
                    isStealingMana = true;
                    StartCoroutine( EatMana(block));
                    break;
                }
            }
        }
    }
    IEnumerator EatMana(Block block)
    {
        bp.AllowOrNoClicks(false);
        //block.PaintBlock(Color.yellow);
        Debug.Log("tut");
        yield return new WaitForSeconds(.5f);
        block.PaintBlock(Color.red);
        yield return new WaitForSeconds(.5f);

        block.EmptyBlock();
        bp.AllowOrNoClicks(true);
        isStealingMana = false;
    }
}
