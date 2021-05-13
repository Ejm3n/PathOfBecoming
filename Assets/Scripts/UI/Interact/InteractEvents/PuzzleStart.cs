using UnityEngine;
public class PuzzleStart : InteractEvent
{
    public PuzzleController puzzleController;
    public GameObject Puzzle;
    [SerializeField] DialogueSystem ds;
    [SerializeField] bool create;

    public override void Start_Event()
    {
        puzzleController.Start_Puzzle(Puzzle, eventTrigger, create);
        ds.SetUI(false);
    }
}

