using UnityEngine;

public class Level1 : Engine
{
    [Header("Other")]
    [SerializeField] GameObject startDialog;

    AudioClip mainTheme;

    private void Awake()
    {
        mainTheme = Resources.Load<AudioClip>("Sounds/Music/ForestTheme");
    }

    protected override void Start_Level()
    {
        Spawn_Characters();
        Show_Scene(() => startDialog.SetActive(true));
        SoundRecorder.Play_Music(mainTheme);
    }

    protected override void Load_Level()
    {
        SoundRecorder.Play_Music(mainTheme);
        base.Load_Level();
    }
}
