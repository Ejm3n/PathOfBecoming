using UnityEngine;
using AnimationUtils.TransformUtils;

public class SliderPuzzleDoor : MonoBehaviour
{
    [SerializeField] Vector3 offset;
    [SerializeField] float time;
    public void Open_Door()
    {
        transform.Move_To(transform.position + offset, time, ()=> Destroy(gameObject));
    }
}
