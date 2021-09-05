
public class Level2 : Engine
{
    protected override void Start_Level()
    {
        Spawn_Characters();
        Connect_Fairy_to_Player();
        Show_Scene(() => dialogueSystem.SetUI(true));
    }
}
