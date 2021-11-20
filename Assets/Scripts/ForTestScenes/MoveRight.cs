using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRight : MonoBehaviour
{
    [SerializeField] float speed;
    Rigidbody2D rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position,new Vector2(transform.position.x+10f,transform.position.y),speed);
    }
}
