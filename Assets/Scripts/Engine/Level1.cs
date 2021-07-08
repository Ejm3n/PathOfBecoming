using UnityEngine;
using AnimationUtils.ImageUtils;

public class Level1 : Engine
{
    [Header("Other")]
    [SerializeField] GameObject startDialog;

    protected override void Start_Level()
    {
        Spawn_Characters();
        curtain.Fade(timeToFade, () => startDialog.SetActive(true));
    }
}
