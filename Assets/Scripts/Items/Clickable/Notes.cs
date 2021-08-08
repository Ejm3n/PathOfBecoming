using UnityEngine;
public class Notes : ClickableItem
{
    public GameObject expanded;

    protected override void On_Click()
    {
        Interface.current.Spawn_UI_Object(expanded);
    }
}
