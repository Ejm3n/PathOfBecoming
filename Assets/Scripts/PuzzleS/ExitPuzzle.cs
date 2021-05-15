using UnityEngine;

public class ExitPuzzle : MonoBehaviour
{
    [SerializeField] GameObject puzzle;

    private void OnMouseDown()
    {
        Exit();
    }

    private void Exit()
    {
        Destroy(puzzle);
    }
}
