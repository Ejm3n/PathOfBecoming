using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] Color defaultColor = Color.white;
    [SerializeField] Sprite defaultSprite;
    [SerializeField] Sprite filledSprite;
    SpriteRenderer sp;
    public bool isFilled = false;
    public int manacost;
    private int defaultMana;
    public bool HaveRazlom;
    public int StolbToFill;
    private Stolb stolb;
    void Start()
    {
        sp = gameObject.GetComponent<SpriteRenderer>();
        stolb = GetComponentInParent<Stolb>();
        defaultMana = manacost;
    }

    public int FillBlock(int currentMana)
    {
        currentMana -= manacost;
        if (currentMana < 0)
            currentMana = 0;
        sp.color = Color.yellow;
        isFilled = true;
        if(HaveRazlom)
        {
            stolb.StartRazlom(this);
        }
        return currentMana;
    }
    public void EmptyBlock()
    {
        manacost = defaultMana;
        sp.color = defaultColor;
        isFilled = false ;
    }
    public void PartFillBlock(int strength)
    {

        sp.color = Color.green;
        manacost -= strength;
        if(manacost<=0)
        {
            int i = 0;
            FillBlock(i);
        }
    }
    public void PaintBlock(Color color)
    {
        sp.color = color;
    }
}
