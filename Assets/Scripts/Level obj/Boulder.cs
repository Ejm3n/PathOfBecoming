using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boulder : MonoBehaviour
{
    SpriteRenderer render;
    EdgeCollider2D coll;
   

    private void Start()
    {
        render = GetComponent<SpriteRenderer>();
        coll = GetComponent<EdgeCollider2D>();
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            render.enabled = false;
            coll.enabled = false;
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            render.enabled = true;
            coll.enabled = true;
        }
    }
}
