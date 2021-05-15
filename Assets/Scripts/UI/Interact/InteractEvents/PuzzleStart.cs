using UnityEngine;
using UnityEngine.Events;
public class PuzzleStart : InteractEvent
{
    public GameObject puzzle;
    [SerializeField] bool create;
    public UnityEvent winEvent;
    public UnityEvent closeEvent;

    [SerializeField] DialogueSystem ds;

    public override void Start_Event()
    {
        interactController.Start_Puzzle(this, create);
        ds.SetUI(false);
    }
}

