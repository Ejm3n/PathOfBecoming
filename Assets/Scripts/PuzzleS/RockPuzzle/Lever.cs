using UnityEngine;

public class Lever : InteractEvent
{
   // [SerializeField] int leverNum;
    [SerializeField] int rockDown;
    [SerializeField] int rockUp;
    [SerializeField] RockController RC;
    public override void Start_Event()
    {
        Debug.Log("PRESSED ON BRANCH & down - " + rockDown + " up - " + rockUp);
        if(!RC.ended)
            RC.ChangeRockPositions(rockUp, rockDown);
    }
    
}
