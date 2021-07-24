using UnityEngine;
using GlobalVariables;

public class Level1 : Engine
{
    [Header("Other")]
    [SerializeField] GameObject startDialog;


    private void Awake()
    {
        mainTheme = Sounds.LEVEL1MUSIC;
        ambient = Sounds.LEVEL1AMBIENT;
        SoundRecorder.Play_Music(mainTheme);
        SoundRecorder.Play_Ambient(ambient);
    }

    protected override void Start_Level()
    {
        Spawn_Characters();
        Show_Scene(() => startDialog.SetActive(true));
    }
}
