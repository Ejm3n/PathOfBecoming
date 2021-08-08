using UnityEngine;

public static class SoundRecorder
{
    public static void Play_Effect(AudioClip clip)
    {
        SoundPlayer.effectsQueue.Enqueue(clip);
    }

    public static void Play_Music(AudioClip clip)
    {
        SoundPlayer.musicQueue.Enqueue(clip);
    }

    public static void Play_Ambient(AudioClip clip)
    {
        SoundPlayer.ambientQueue.Enqueue(clip);
    }
}