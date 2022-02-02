using PlayerControls;

public class PuzzleHandler : UncontrollableHandler
{

    public override void Interact()
    {
        base.Interact();
        if (ControlButtonsPress.INTERACT)
            Puzzle.current.Solve_Puzzle();
    }

    public override void Switch_Spell()
    {
        if (ControlButtonsPress.SWITCHSPELL)
            Puzzle.current.Fail_Puzzle();
    }
}
