using UnityEngine;

public class MermaidAnimatorController : MonoBehaviour
{
    [SerializeField] private Animator anim;

    public void StartReadingAnim()
    {
        anim.SetTrigger("IsReading");
    }
}
