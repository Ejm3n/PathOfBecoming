using UnityEngine;

public class InteractController : MonoBehaviour
{
    [HideInInspector] public bool buttonEnabled;

    PuzzleStart puzzleStart;

    public void Start_Puzzle(PuzzleStart puzzleStart, bool create)
    {
        this.puzzleStart = puzzleStart;
        if (create)
            Instantiate(puzzleStart.puzzle, gameObject.transform);
        else
            puzzleStart.puzzle.SetActive(true);
    }

    public void Handle_Puzzle_result(bool solved)
    {
        if (solved)          
            puzzleStart.winEvent?.Invoke();
        else
            puzzleStart.closeEvent?.Invoke();
    }


}
