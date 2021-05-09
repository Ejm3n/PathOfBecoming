using UnityEngine;
public class PuzzleStart : InteractEvent
{
    public GameObject Puzzle;
    [SerializeField] DialogueSystem ds;

    public override void Start_Event()
    {
        Puzzle.SetActive(true);
        ds.SetUI(false);
    }
}

