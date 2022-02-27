using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundSlidersController : MonoBehaviour
{
   // [SerializeField] private Slider masterVolSlider;

    private GameSettings gameSettings;

    private void Awake()
    {
        gameSettings = SaveSyatem.gameSettings;
    }
    public void OnMasterSliderValueChange(float val)
    {
        gameSettings.soundSettings.masterVolume = val;
    }
    public void OnMusicSliderValueChange(float val)
    {
        gameSettings.soundSettings.musicVolume = val;
    }
    public void OnSoundSliderValueChange(float val)
    {
        gameSettings.soundSettings.effectsVolume = val;
    }
    public void SaveAndExit()
    {
        SaveSyatem.gameSettings = gameSettings;
        //change screens
    }
}
