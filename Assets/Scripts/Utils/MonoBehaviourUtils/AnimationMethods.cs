using UnityEngine;
using UnityEngine.Events;

public class AnimationMethods : MonoBehaviour
{
    [SerializeField] UnityEvent onAnimationEnd;
    Animation anim;

    private void Start()
    {
        anim = GetComponent<Animation>();
    }

    public void Play_Animation()
    {
        anim.Play();
    }

    public void Destroy_Obj()
    {
        Destroy(gameObject);
    }

    public void Animation_End()
    {
        onAnimationEnd?.Invoke();
    }
}
