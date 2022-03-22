using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DrawPuzzle : MonoBehaviour
{
    List<SpriteRenderer> spriteRenderers;
    List<CircleCollider2D> circleColliders;
    private void Awake()
    {
        circleColliders = new List<CircleCollider2D>();
        for (int i = 0; i < transform.childCount; i++)
        {           
            circleColliders.Add(transform.GetChild(i).GetComponent<CircleCollider2D>());
        }        
    }
    private void FixedUpdate()
    {
        if(true)
        {
            Debug.Log("a");
            Touch touch = Input.GetTouch(0);
            Vector2 fingerPos = new Vector2(touch.position.x, touch.position.y);
            Ray ray = Camera.main.ScreenPointToRay(fingerPos);
            
            Vector3 hitpoint;
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log("hit");
                hitpoint = hit.point;
                hit.collider.GetComponent<SpriteRenderer>().color = Color.red;
                hit.collider.GetComponent<CircleCollider2D>().enabled = false;
            }
        }       
    }
}
