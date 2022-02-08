using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Begunok : MonoBehaviour
{
    public int NumberTimesWent;
    [SerializeField] Vector2[] points;
    [SerializeField] float speed;
    int currentPoint=1;
    public bool AtTopPoint = false;
    private void Update()
    {
        AtTopPoint = false;

        if (points[currentPoint].y != transform.localPosition.y)
        {
            
            transform.localPosition = Vector2.MoveTowards(transform.localPosition, points[currentPoint], speed);
        }
        else
        {
            if (currentPoint == 0)
            {
                AtTopPoint = true;
                NumberTimesWent++;
                // DoubleSpeed();
                currentPoint = 1;
            }
            else
            {
                currentPoint = 0;
            }
        }
    }
   public float GetMaxHeight()
    {
        return points[0].y;
    }
    public float GetCurrentHeight()
    {
        return transform.localPosition.y;
    }
    public void DoubleSpeed()
    {
        speed =speed * 2;
    }
}
