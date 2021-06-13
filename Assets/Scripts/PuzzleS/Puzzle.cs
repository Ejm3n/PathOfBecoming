using UnityEngine;

public class Puzzle : MonoBehaviour
{
    bool solved = false;
    InteractController puzzleController;

    private void Awake()
    {
        puzzleController = transform.parent.GetComponent<InteractController>();
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
