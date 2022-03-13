using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PescernikAnimatorController : MonoBehaviour
{
    [SerializeField] private AudioClip[] walk;
    [SerializeField] private AudioSource audioSource;

    public void PlayStep(int num)
    {
        audioSource.PlayOneShot(walk[num]);
        //SoundRecorder.Play_Effect(walk[num]);
    }
}
