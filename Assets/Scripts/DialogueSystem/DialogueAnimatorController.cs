using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueAnimatorController : MonoBehaviour
{
    [SerializeField] private AudioClip openingPanel;
    public void PlayOpeningSound()
    {
        SoundRecorder.Play_Effect(openingPanel);
    }
}
