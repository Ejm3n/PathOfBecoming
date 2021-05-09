using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
   // [SerializeField] int leverNum;
    [SerializeField] int rockDown;
    [SerializeField] int rockUp;
    [SerializeField] RockController RC;
    private void OnMouseUp()
    {
        RC.ChangeRockPositions(rockUp, rockDown);
    }
    
}
