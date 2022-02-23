using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimEventCrack : MonoBehaviour
{
    Animator anim;
    [SerializeField] Sprite black;
    [SerializeField] Sprite orange;
    [SerializeField] Sprite yellow;
    SpriteRenderer sr;
    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
            anim.SetTrigger("Black");
        if (Input.GetKeyDown(KeyCode.W))
            anim.SetTrigger("Orange");
        if (Input.GetKeyDown(KeyCode.E))
            anim.SetTrigger("Yellow");
    }
    public void OnYellowChange()
    {
        //sr.sprite = black;
    }
    public void OnBlackChange()
    {
        //sr.sprite = orange;
    }
    public void OnOrangeChange()
    {
       // sr.sprite = yellow;
    }
}
