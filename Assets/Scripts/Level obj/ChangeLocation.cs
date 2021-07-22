using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AnimationUtils.ImageUtils;
using Cinemachine;
using UnityEngine.UI;
//ПЕРЕМЕЩЕНИЕ ИГРОКА И КАМЕРЫ
public class ChangeLocation : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera playerCamera;
    [SerializeField] Image fade;
    [SerializeField] float timeToFade;
    [SerializeField] GameObject player;
    Vector2 cavePos = new Vector2(-25.74f, 14.9f);
    Vector2 outSidePos = new Vector2(-0.77f,-2.99f);
    private void OnMouseUp()
    {
        fade.Fade(timeToFade, () => MovePlayerAndCam(true));
    }
    private void MovePlayerAndCam(bool goIN)
    {
        if(goIN)
        {
            player.transform.position = cavePos;
            playerCamera.Priority = 11;
        }
        else
        {
            player.transform.position = outSidePos;
            playerCamera.Priority = 1;
        }
    }
}
