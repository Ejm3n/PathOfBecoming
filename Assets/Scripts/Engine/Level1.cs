using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AnimationUtils.ImageUtils;

public class Level1 : Engine
{
    [SerializeField] GameObject startDialog;
    protected override void LoadLevel()
    {
        //load level
    }

    protected override void Start_Level()
    {
        Spawn_Characters();
        curtain.Fade(timeToFade, () => startDialog.SetActive(true));
    }

    public void Connect_Fairy()
    {
        fairyController.Connect_Fairy(playerController.fairyAnchor);
    }
}
