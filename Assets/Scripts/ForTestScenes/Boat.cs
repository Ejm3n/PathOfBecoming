using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boat : MonoBehaviour
{

    [SerializeField] private float riverSpeed;
    [SerializeField] private float windForcePower;
    [SerializeField] private float timeToForce = 0.3f;
    private bool isForcing = false;
    private float delay;
    private float force;
    private SpriteRenderer sr;
    private int health = 3;
    private Rigidbody2D rb;
    private Dictionary<int, Color> colors = new Dictionary<int, Color>()
    {
        { 0,Color.black },
        { 1,Color.red},
        { 2,Color.green},
        {3,Color.white}
    };
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        Debug.Log(health);
        sr = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        if(health>0)
        {           
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(transform.position.x + 10f, transform.position.y), riverSpeed * Time.deltaTime);
            if (!isForcing)
            {
                if (Input.GetKeyDown(KeyCode.A))
                {
                    force = -windForcePower;
                    isForcing = true;
                    delay = timeToForce;
                }
                else if (Input.GetKeyDown(KeyCode.D))
                {
                    force = windForcePower;
                    isForcing = true;
                    delay = timeToForce;
                }               
            }
            if (isForcing)
            {
                delay -= Time.deltaTime;
                if (delay <= 0)
                {
                    isForcing = false;
                }
                transform.position = Vector2.MoveTowards(transform.position, new Vector2(transform.position.x + 10f, transform.position.y), force * riverSpeed * Time.deltaTime);
            }           
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("CaveRocks"))
        {
            TakeDamage();
            Destroy(collision.gameObject);
        }
           
    }
    private void TakeDamage()
    {       
        health--;
        ChangeColor();
        Debug.Log(health);
    }
    private void ChangeColor()
    {
        if(colors.ContainsKey(health))
        {
            sr.color = colors[health];
        }
    }
}
//transform.position = Vector2.MoveTowards(transform.position, new Vector2(transform.position.x + 10f, transform.position.y), riverSpeed * Time.deltaTime);
//float force = Input.GetAxis("Horizontal") * windForcePower;
//if (force != 0)
//    transform.position = Vector2.MoveTowards(transform.position, new Vector2(transform.position.x + 10f, transform.position.y), force * riverSpeed * Time.deltaTime);