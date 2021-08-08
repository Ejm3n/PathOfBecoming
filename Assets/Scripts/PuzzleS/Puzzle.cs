using UnityEngine;

public class Puzzle : MonoBehaviour
{
    bool solved = false;
    PuzzleController puzzleController;

    private void Awake()
    {
        puzzleController = transform.parent.GetComponent<PuzzleController>();
    }

    public void Solve_Puzzle()
    {
        solved = true;
        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        puzzleController.Handle_Puzzle_result(solved);
    }
}
