using UnityEngine;

public class InteractController : MonoBehaviour
{
    public GameObject interactButton;
    [HideInInspector] public bool buttonEnabled;

    PuzzleStart puzzleStart;

    public void Activate_Interact_Button(bool activate)
    {
        if (activate)
        {
            interactButton.SetActive(buttonEnabled);
        }
        else
        {
            buttonEnabled = interactButton.activeInHierarchy;
            interactButton.SetActive(false);
        }
    }

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
            puzzleStart.winEvent?.Invoke();
        }
        else
        {
            interactButton.SetActive(true);
            puzzleStart.closeEvent?.Invoke();
        }
    }


}
