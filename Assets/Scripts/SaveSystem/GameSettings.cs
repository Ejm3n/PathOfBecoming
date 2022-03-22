using System;

[Serializable]
public class GameSettings
{
    public SoundSettings soundSettings;

    public GameSettings(SoundSettings soundSettings)
    {
        this.soundSettings = soundSettings;
    }

    public GameSettings()
    {
        soundSettings = new SoundSettings();
    }
}

[Serializable]
public class SoundSettings
{
    public float musicVolume;
    public float effectsVolume;
    public float masterVolume;
    public SoundSettings(float musicVolume, float effectsVolume, float masterVolume)
    {
        this.musicVolume = musicVolume;
        this.effectsVolume = effectsVolume;
        this.masterVolume = masterVolume;
    }

    public SoundSettings()
    {
        musicVolume = 1;
        effectsVolume = 1;
        masterVolume = 1;
    }
}

