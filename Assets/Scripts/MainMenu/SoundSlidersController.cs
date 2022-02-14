using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundSlidersController : MonoBehaviour
{
    private GameSettings gameSettings;

    private void Awake()
    {
        gameSettings = SaveSyatem.gameSettings;
    }
    public void OnMasterSliderValueChange()
    {
        
    }
    public void SaveAndExit()
    {
        SaveSyatem.gameSettings = gameSettings;
        //change screens
    }
}
