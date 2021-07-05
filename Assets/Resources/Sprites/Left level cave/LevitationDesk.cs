using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevitationDesk : MonoBehaviour
{
    bool moveto2pos;
    Vector3 pos1 = new Vector3(3.48f, -2.13f);
    Vector3 pos2 = new Vector3(-0.3f,-2.78f);
    float speed = 0.01f;
    void Update()
    {
        //if(moveto2pos && transform.position != pos2)
        //{
        //    transform.position = Vector3.MoveTowards(transform.position,pos2,speed);
        //}
        //else if(transform.position == pos2)
        //{
        //    moveto2pos = false;
        //}
        //if(!moveto2pos && transform.position != pos1)
        //{
        //    transform.position = Vector3.MoveTowards(transform.position, pos1, speed);
        //}
        //else if(transform.position == pos1)
        //{
        //    moveto2pos = true;
        //}
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            collision.transform.parent = transform;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.transform.parent = null;
        }
    }
}
