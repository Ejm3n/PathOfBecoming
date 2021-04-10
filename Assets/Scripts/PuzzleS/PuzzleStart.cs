using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleStart : MonoBehaviour
{
    public GameObject Pazzle;

    public void OnMouseDown()
    {
        if(Pazzle!=null)
        {
            Pazzle.SetActive(true);
        }
      
    }
}
