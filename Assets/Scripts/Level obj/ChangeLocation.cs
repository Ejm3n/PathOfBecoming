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

    GameObject player;
    Vector2 cavePos = new Vector2(-25.74f, 14.9f);
    Vector2 outSidePos = new Vector2(-0.77f,-2.99f);
    [SerializeField] float fadeTime;
    [SerializeField] Image fadeToBlack;
    private void OnMouseUp()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        MoveIt(true);
    }
    public IEnumerator MovePlayerAndCam(bool goIN)
    {
        Engine.current.Hide_Scene();
        Debug.Log("0");
        yield return new WaitForSeconds(fadeTime);
        if(goIN)
        {
            Debug.Log("1");
            player.transform.position = cavePos;
            playerCamera.Priority = 11;
        }
        else
        {
            player.transform.position = outSidePos;
            playerCamera.Priority = 1;
        }
       
        yield return new WaitForSeconds(fadeTime);
        Engine.current.Show_Scene();       
    }
    public void MoveIt(bool goIN)
    {
        StartCoroutine(MovePlayerAndCam(goIN));
    }
}
