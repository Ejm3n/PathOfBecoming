using System;
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
    [SerializeField] private Material material;
    bool haveSound = true;
    GameObject player;
    int currentMovingPoint;
    bool attacking = false;
    SpriteRenderer[] playerSR;
    bool isHasling = false;
    
    private void Start()
    {
        player = Engine.current.player;        
    }

    void Update()
    {
        if(!isHasling)
        {
            attacking = Physics2D.OverlapCircle(transform.position, radiusToFindPlayer, playerLayer);
            if (!attacking)
            {
                if (new Vector2(transform.position.x, transform.position.y) != positionsToPatrol[currentMovingPoint])
                    transform.position = Vector2.MoveTowards(transform.position, positionsToPatrol[currentMovingPoint], speed);
                else
                {
                    if (goingRight)
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
                    {
                        GameObject playerChild = Engine.current.player.transform.GetChild(0).gameObject;
                        playerSR = playerChild.GetComponentsInChildren<SpriteRenderer>();
                    }

                    //sound
                    SoundRecorder.Play_Effect(attack);
                    foreach (SpriteRenderer sr in playerSR)
                    {
                        sr.color = new Color(sr.color.r - .33f, sr.color.g - .33f, sr.color.b - .33f, 1f);
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
                    gameObject.SetActive(false);
                }
                if (speed < maxSpeed)
                {
                    speed += 0.0001f;
                }
            }
        }
        
    }
    private void OnDisable()
    {
        
        //Hassle_Disappear(1f);
    }
    
    private void OnEnable()
    {
        //Hassle_Appear(.1f);
        material.SetFloat("_Fade", 1);
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
    public void SilentlyDisable()
    {
        haveSound = false;
        gameObject.SetActive(false);
    }
    public void Hassle_Disappear(float procTime)
    {
        StartCoroutine(Hassle_Proc(1f, 0f, procTime, () => gameObject.SetActive(false)));
        
    }

    public void Hassle_Appear(float procTime)
    {
        gameObject.SetActive(true);
        StartCoroutine(Hassle_Proc(0f, 1f, procTime));
    }

    IEnumerator Hassle_Proc(float fadeFrom, float fadeTo, float procTime, Action onComplete = null)
    {
        if (haveSound)
            SoundRecorder.Play_Effect(die);
        isHasling = true;
        float iter = (fadeTo - fadeFrom) / procTime;
        float currentFade = fadeFrom;
        while (Mathf.Abs(fadeTo - currentFade) > 0.001f)
        {
            currentFade += iter * Time.deltaTime;
            currentFade = Mathf.Clamp(currentFade, 0, 1);
            material.SetFloat("_Fade", currentFade);
            yield return null;
        }
        
        isHasling = false;
        onComplete?.Invoke();
        
        //gameObject.SetActive(false);
    }
}
