using UnityEngine;

public class PuzzleController : MonoBehaviour
{
    public GameObject interactButton;

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
        {
            Destroy(puzzleStart.eventTrigger);
            puzzleStart.winEvent?.Invoke();
        }
        else
        {
            interactButton.SetActive(true);
            puzzleStart.closeEvent?.Invoke();
        }
    }
}
