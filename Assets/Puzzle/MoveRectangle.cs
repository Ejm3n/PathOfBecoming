using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveRectangle : MonoBehaviour
{
    public GameObject left;
    public GameObject right;
    public GameObject plane;
    Vector2 planeSize;

    private float startPosition;
    private bool mouseDown = false;
    private Vector2 screenBorder1, screenBorder2;
    private Vector2 spriteSize;

    private void Start()
    {
        planeSize = plane.GetComponent<RectTransform>().sizeDelta;
        if (gameObject.CompareTag("Horizontal"))
            startPosition = GetComponent<Transform>().position.y;
        if (gameObject.CompareTag("Vertical"))
            startPosition = GetComponent<Transform>().position.x;
        screenBorder1 = Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height));
        screenBorder2 = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));

        spriteSize = GetComponent<SpriteRenderer>().bounds.size;
        Debug.Log(planeSize);
    }

    private void OnMouseDown()
    {
        mouseDown = true;
    }

    private void OnMouseUp()
    {
        mouseDown = !mouseDown;
    }

    private void Update()
    {
        Vector3 cursor = Input.mousePosition;
        cursor = Camera.main.ScreenToWorldPoint(cursor);
        //Debug.Log(cursor);
        cursor.z = 0;
        if (gameObject.CompareTag("Horizontal"))
        {
            cursor.y = startPosition;
            if (transform.position.x - spriteSize.x * 2 < screenBorder1.x || transform.position.x + spriteSize.x * 2 > screenBorder2.x)
            {
                //cursor.x = Mathf.Clamp(cursor.x, screenBorder1.x, screenBorder2.x - (spriteSize.x + spriteSize.x / 2));
                cursor.x = Mathf.Clamp(cursor.x, screenBorder1.x + spriteSize.x / 3, screenBorder2.x - spriteSize.x / 2);
                //Debug.Log("!!!");
            }
        }
        if (gameObject.CompareTag("Vertical"))
            cursor.x = startPosition;

        if (mouseDown)
        {
            this.transform.position = cursor;
        }

        
        //if (transform.position.y > border2.y || transform.position.x < border1.y)
        //{
        //    Debug.Log("!!!");
        //}
    }

}
