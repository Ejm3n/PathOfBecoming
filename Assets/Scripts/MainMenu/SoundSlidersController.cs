using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundSlidersController : MonoBehaviour
{
    [SerializeField] private Slider masterVolSlider;

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
