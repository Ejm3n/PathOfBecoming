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

    public SoundSettings(float musicVolume, float effectsVolume)
    {
        this.musicVolume = musicVolume;
        this.effectsVolume = effectsVolume;
    }

    public SoundSettings()
    {
        musicVolume = 1;
        effectsVolume = 1;
    }
}

