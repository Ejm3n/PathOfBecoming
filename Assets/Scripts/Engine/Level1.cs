using UnityEngine;

public class Level1 : Engine
{
    const string LEVEL1MUSIC = "Sounds/Music/ForestTheme";
    const string LEVEL1AMBIENT = "Sounds/Effects/forestambient";


    protected override void Awake()
    {
        mainTheme = Resources.Load<AudioClip>(LEVEL1MUSIC);
        ambient = Resources.Load<AudioClip>(LEVEL1AMBIENT);
        base.Awake();
    }

    protected override void Start_Level()
    {
        Spawn_Characters();
        Show_Scene(() => startDialog.SetActive(true));
    }
}
