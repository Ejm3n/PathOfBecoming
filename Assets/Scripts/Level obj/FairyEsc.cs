using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FairyEsc : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField] Transform target;
    [SerializeField] bool isFairyAttached;

    private void Update()
    {
        if (PazzleControl.youWin && !isFairyAttached)
        {
            transform.SetParent(target);
            transform.localPosition = Vector3.zero;
            isFairyAttached = true;
        }
    }

   // void Flip()
    //{
    //    if (Input.GetAxis("Horizontal") < 0)
    //    {
    //        transform.localRotation = Quaternion.Euler(0, 0, 0);
   //     }

   //     if (Input.GetAxis("Horizontal") > 0)
   //     {
   //         transform.localRotation = Quaternion.Euler(0, 180, 0);
   //     }

   // }
}
