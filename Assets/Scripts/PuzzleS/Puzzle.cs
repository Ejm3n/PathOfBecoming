using UnityEngine;

public class Puzzle : MonoBehaviour
{
    protected bool solved = false;
    PuzzleController puzzleController;

    private void Awake()
    {
        puzzleController = transform.parent.GetComponent<PuzzleController>();
    }


    private void OnDestroy()
    {
        puzzleController.Handle_Puzzle_result(solved);
    }
}
