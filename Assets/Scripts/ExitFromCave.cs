using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitFromCave : MonoBehaviour
{
    //супер костыль но я хочу спать
    ChangeLocation CL;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        CL = FindObjectOfType<ChangeLocation>();
        CL.MoveIt(false);
    }
}
