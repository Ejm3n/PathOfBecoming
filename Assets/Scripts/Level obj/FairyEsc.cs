using UnityEngine;

public class FairyEsc : MonoBehaviour
{
    [SerializeField] Transform target;

    public void Free_Fairy()
    {
        transform.SetParent(target);
        transform.localPosition = Vector3.zero;
    }
}
