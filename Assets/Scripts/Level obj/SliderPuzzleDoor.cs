using UnityEngine;
using AnimationUtils.TransformUtils;

public class SliderPuzzleDoor : MonoBehaviour
{
    public void Open_Door()
    {
        Vector3 offset = transform.position + Vector3.right * 3;
        transform.Move_To(offset, 0.3f);
    }
}
