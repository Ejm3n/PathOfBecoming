using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AnimationUtils.ImageUtils;
using Cinemachine;
//ПЕРЕМЕЩЕНИЕ ИГРОКА И КАМЕРЫ
public class ChangeLocation : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera playerCamera;
    [SerializeField] float timeToFade;
    private void OnMouseUp()
    {
        //playerCamera.Fade(timeToFade, () => playerCamera.Priority = 11);
    }
}
