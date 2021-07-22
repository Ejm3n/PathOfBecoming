using UnityEngine;
public class PuzzleStart : InteractEvent
{
    public GameObject puzzle;
    [SerializeField] bool create;

    [SerializeField] DialogueSystem ds;

    public override void Start_Event()
    {
        if (TryGetComponent<Collider2D>(out Collider2D coll))
        {
            coll.enabled = false;
            onFail.AddListener(() => coll.enabled = true);
        }           
        interactController.Start_Puzzle(this, create);
        ds.SetUI(false);
    }
}

