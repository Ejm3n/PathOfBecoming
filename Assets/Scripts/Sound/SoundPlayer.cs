using System.Collections.Generic;
using UnityEngine;

public class SoundPlayer : MonoBehaviour
{
    [SerializeField] AudioSource effectsSound;
    [SerializeField] AudioSource musicSound;

    Engine engine;

    static public Queue<AudioClip> effectsQueue = new Queue<AudioClip>();
    static public Queue<AudioClip> musicQueue = new Queue<AudioClip>();

    private void Awake()
    {
        engine = transform.parent.GetComponent<Engine>();
    }

    void Update()
    {
        Check_Effects_Queue();
        Check_Music_Queue();
    }

    void Check_Effects_Queue()
    {
        while (effectsQueue.Count > 0)
        {
            effectsSound.PlayOneShot(effectsQueue.Dequeue(), engine.gameSettings.soundSettings.effectsVolume);
        }
    }

    void Check_Music_Queue()
    {
        if (musicQueue.Count > 0)
        {
            musicSound.clip = musicQueue.Dequeue();
            musicSound.Play();
        }
        if (musicSound.volume != engine.gameSettings.soundSettings.musicVolume)
            musicSound.volume = engine.gameSettings.soundSettings.musicVolume;
    }
}