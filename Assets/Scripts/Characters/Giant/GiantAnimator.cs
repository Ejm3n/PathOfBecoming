using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiantAnimator : MonoBehaviour
{
    [SerializeField] private GameObject platformForMushroom;
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
        animator.SetTrigger("Idle");
    }
    public void ChangeToShutting()
    {
        animator.SetTrigger("Shutting");
    }
    public void ChangeToShiver()
    {
        animator.SetTrigger("Shiver");
    }
    public void ChangeToSneeze()
    {
        animator.SetTrigger("Sneeze");
    }
    public void MushroomFalling()
    {
        platformForMushroom.SetActive(false);
    }
}
