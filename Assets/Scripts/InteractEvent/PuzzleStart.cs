using UnityEngine;
public class PuzzleStart : InteractEvent
{
    public GameObject puzzle;
    [SerializeField] bool create;

    public override void Start_Event()
    {
        base.Start_Event();
        Engine.current.puzzleController.Start_Puzzle(this, create);
        Engine.current.dialogueSystem.SetUI(false);
    }
}

