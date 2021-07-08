using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1x1 : Level1
{
    protected override void Start_Level()
    {
        base.Start_Level();
        Connect_Fairy_to_Player();
    }
}
