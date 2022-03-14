using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiantAnimator : MonoBehaviour
{
    [SerializeField] private GameObject platformForMushroom;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip sneezeSound;
    [SerializeField] private AudioClip rumblingSound;
    [SerializeField] private AudioClip shape;
    [SerializeField] private AudioClip shapeOff;
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        ChangeToShutting();
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        ChangeToIdle();
    }
    public void ChangeToIdle()
    {
        audioSource.PlayOneShot(shape);
        animator.SetTrigger("Idle");
    }
    public void ChangeToShutting()
    {
        audioSource.PlayOneShot(shapeOff);
        animator.SetTrigger("Shutting");
    }
    public void ChangeToShiver()
    {
        audioSource.PlayOneShot(rumblingSound);
        animator.SetTrigger("Shiver");
    }
    public void ChangeToSneeze()
    {
        audioSource.PlayOneShot(sneezeSound);
        animator.SetTrigger("Sneeze");
    }
    public void MushroomFalling()
    {
        platformForMushroom.SetActive(false);
    }
}
