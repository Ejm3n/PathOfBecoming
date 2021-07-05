using System;
using UnityEngine;
using AnimationUtils.ImageUtils;

public class Level1 : Engine
{
    [SerializeField] GameObject startDialog;
    protected override void LoadLevel()
    {
        SaveData data;
        try
        {
            data = SaveSyatem.Load();
            Spawn_Characters(data.playerData.lastCheckpoint.Convert_to_UnityVector(), data.fairyData.checkPoint.Convert_to_UnityVector());
            playerController.Load_State(data.playerData);
            fairyController.Load_State(data.fairyData);
        }
        catch (NullReferenceException)
        {
            Start_Level();
        }
    }

    protected override void Start_Level()
    {
        Spawn_Characters();
        curtain.Fade(timeToFade, () => startDialog.SetActive(true));
    }
}
