using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingForest : MonoBehaviour
{
    public float paralaxSpeed;
    public float paralaxJump;

    private Transform cameraTransform;
    private float lastCameraX;
    private float lastCameraY;


    private void Start()
    {
        cameraTransform = Camera.main.transform;
        lastCameraX = cameraTransform.position.x;
        lastCameraY = cameraTransform.position.y;
    }

    private void Update()
    {
        float deltaX = cameraTransform.position.x - lastCameraX;
        transform.position += Vector3.right * (deltaX * paralaxSpeed);
        lastCameraX = cameraTransform.position.x;

        float deltaY = cameraTransform.position.y - lastCameraY;
        transform.position += Vector3.up * (deltaY * paralaxJump);
        lastCameraY = cameraTransform.position.y;
    }
}
