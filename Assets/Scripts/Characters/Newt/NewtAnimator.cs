using UnityEngine;
using AnimationUtilsAsync.TransformUtils;
public class NewtAnimator : MonoBehaviour
{
    [SerializeField] private Transform newtTransform;
    [SerializeField] private Transform movePoint;
    [SerializeField] private AudioClip[] steps;
    [SerializeField] private AudioClip fallingSound;
    [SerializeField] private AudioSource source;
    private Animator animator;
    
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void ChangeToWalk()
    {
        Engine.current.playerController.Change_Controls<UncontrollableHandler>();
        animator.SetTrigger("Walk");
        newtTransform.Move_To(movePoint.position, 6f, () => { ChangeToFalling(); });
    }
    public void ChangeToFalling()
    {
        animator.SetTrigger("Falling");
        Engine.current.playerController.Change_Controls<DefaultHandler>();
    }
    public void ChangeToAwake()
    {
        animator.SetTrigger("Awake");
    }
    public void ChangeToIdle()
    {
        animator.SetTrigger("Idle");
    }
    public void WalkingSound    (int stepSound)
    {
        source.PlayOneShot(steps[stepSound]);
    }
    public void FallingSound()
    {
        source.PlayOneShot(fallingSound);
    }

}
