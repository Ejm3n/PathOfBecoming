using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : InteractEvent
{
   // [SerializeField] int leverNum;
    [SerializeField] int rockDown;
    [SerializeField] int rockUp;
    [SerializeField] RockController RC;
    public override void Start_Event()
    {
        RC.ChangeRockPositions(rockUp, rockDown);
    }
    
}
