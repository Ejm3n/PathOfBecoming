using PlayerControls;
using UnityEngine;

public abstract class ControlHandler
{
    public abstract void Up();
    public abstract void Down();
    public abstract void Left();
    public abstract void Right();
    public abstract void Interact();
    public abstract void Switch_Spell();
    public abstract void Use_Spell();
    public abstract void Inventory_Button();

    public virtual void Pause()
    {
        if (ControlButtonsPress.PAUSE)
            if(Time.timeScale == 1)
                Engine.current.Pause();
            else
                Engine.current.Continue();
    }

    public void Action()
    {
        Up();
        Down();
        Left();
        Right();
        Interact();
        Switch_Spell();
        Use_Spell();
        Inventory_Button();
        Pause();
    }
}
