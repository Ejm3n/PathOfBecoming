using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PescernikAnimatorController : MonoBehaviour
{
    [SerializeField] private AudioClip[] walk;
    public void PlayStep(int num)
    {
        SoundRecorder.Play_Effect(walk[num]);
    }
}
