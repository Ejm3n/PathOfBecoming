using UnityEngine;

public class SoundRecorder : MonoBehaviour
{
    public static void Play_Effect(AudioClip clip)
    {
        SoundPlayer.effectsQueue.Enqueue(clip);
    }

    public static void Play_Music(AudioClip clip)
    {
        SoundPlayer.musicQueue.Enqueue(clip);
    }
}