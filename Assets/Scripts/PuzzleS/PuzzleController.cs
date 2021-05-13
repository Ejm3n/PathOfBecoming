using UnityEngine;

public class PuzzleController : MonoBehaviour
{
    public GameObject interactButton;

    Collider2D puzzleTrigger;

    
    public void Start_Puzzle(GameObject puzzle, Collider2D trigger, bool create)
    {
        puzzleTrigger = trigger;
        if (create)
            Instantiate(puzzle, gameObject.transform);
        else
            puzzle.SetActive(true);
    }

    public void Handle_Puzzle_result(bool solved)
    {

    }
}
