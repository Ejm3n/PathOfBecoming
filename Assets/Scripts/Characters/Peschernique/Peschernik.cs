using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Peschernik : MonoBehaviour
{
    [SerializeField]Vector2[] positionsToPatrol;
    [SerializeField] float radiusToFindPlayer;
    [SerializeField] float speed;
    [SerializeField] float minSpeed;
    [SerializeField] float maxSpeed;
    [SerializeField] LayerMask playerLayer;
    [SerializeField] bool goingRight;
    [SerializeField] private Vector2 defaultPosition;
    [SerializeField] private AudioClip attack;
    
    [SerializeField] private AudioClip die;
    //[SerializeField] private AudioClip attack;

    GameObject player;
    int currentMovingPoint;
    bool attacking = false;
    SpriteRenderer[] playerSR;

    private void Start()
    {
        player = Engine.current.player;        
    }

    void Update()
    {
        attacking = Physics2D.OverlapCircle(transform.position,radiusToFindPlayer,playerLayer);
        if(!attacking)
        {
            if (new Vector2(transform.position.x,transform.position.y) != positionsToPatrol[currentMovingPoint]) 
                transform.position = Vector2.MoveTowards(transform.position, positionsToPatrol[currentMovingPoint],speed);
            else 
            {
                if(goingRight)
                {
                    if (currentMovingPoint < positionsToPatrol.Length - 1)
                        currentMovingPoint++;
                    else
                        Flip();                       
                }
                else
                {
                    if (currentMovingPoint > 0)
                        currentMovingPoint--;
                    else
                        Flip();
                }
                
            }               
        }
        else
        {
            if (transform.position != Engine.current.player.transform.position)
            {
                transform.position = Vector2.MoveTowards(transform.position, Engine.current.player.transform.position, speed);
            }
            else
            {   
                if (playerSR == null)
                    playerSR = Engine.current.player.GetComponentsInChildren<SpriteRenderer>();
                //sound
                SoundRecorder.Play_Effect(attack);
                foreach (SpriteRenderer sr in playerSR)
                {
                    sr.color = new Color(sr.color.r-.33f, sr.color.g-.33f, sr.color.b-.33f,1f);                    
                }
                if (playerSR[0].color.r < .1)
                {
                    Debug.Log("СМЕРТЬ ОТ ПЕЩЕРНИКА");
                    foreach (SpriteRenderer sr in playerSR)
                    {
                        sr.color = new Color(255, 255, 255, 1f);
                    }
                    player.GetComponent<PlayerController>().Die();
                }
                Destroy(gameObject);
            }
            if(speed<maxSpeed)
            {
                speed += 0.0001f;
            }
        }
    }
    private void OnDisable()
    {
        SoundRecorder.Play_Effect(die);
    }
    private void Flip()
    {
        goingRight = !goingRight;
        transform.Rotate(Vector3.up * 180);
    }
    
    public void SetDefaultPosition()
    {
        transform.position = defaultPosition;
    }
}
