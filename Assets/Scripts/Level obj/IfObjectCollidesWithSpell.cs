using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IfObjectCollidesWithSpell : MonoBehaviour
{
    //[SerializeField] SpriteRenderer[] spritesToActivate;
    //[SerializeField] SpriteRenderer[] spritesToDeactivate;
    [SerializeField] Animator anim;
    [SerializeField] Animation an;
    [SerializeField] string spellName;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("---");
        if (collision.gameObject.name == spellName + "(Clone)")
        {
            Debug.Log("+++");
            anim.Play("RottenTreeFall");
        }
    }
}
