using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FairyEsc : MonoBehaviour
{
    [SerializeField]
    private float speed;
    private Transform target;
    float smoothTime = 0.6f;
    float yVelocity = 0.0f;
    [SerializeField] bool isFairyAttached;

    private void Start()
    {
        if(!isFairyAttached)
        {
           
            transform.position = new Vector2(52, 4.5f);
        }
        target = GameObject.FindGameObjectWithTag("TargetFairy").transform;
    }

    private void Update()
    {
        if (PazzleControl.youWin || isFairyAttached)
        {
            float newPosition = Mathf.SmoothDamp(transform.position.x, target.position.x, ref yVelocity, smoothTime);
            transform.position = new Vector3(newPosition, target.position.y, transform.position.z);
            //Flip();
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
