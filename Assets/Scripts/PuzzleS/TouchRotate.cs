using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchRotate : MonoBehaviour
{
    
    public void OnMouseDown()
    {
        if (!PazzleControl.youWin)
        {
            StartCoroutine(Rotate());
        }
    }

    IEnumerator Rotate()
    {
        transform.Rotate(0, 0, -15);
        yield return new WaitForSecondsRealtime(0.1f);
        transform.Rotate(0, 0, -15);
        yield return new WaitForSecondsRealtime(0.1f);
        transform.Rotate(0, 0, -15);
        yield return new WaitForSecondsRealtime(0.1f);
        transform.Rotate(0, 0, -15);
        yield return new WaitForSecondsRealtime(0.1f);

    }
}
