using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampoline : MonoBehaviour
{
    [SerializeField] private float _power;

    private bool _trampoline = false;

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (!Engine.current.playerController.isGround)
            Engine.current.playerController.rb.AddForce(Vector2.up * _power * (_trampoline ? 1 : 0), ForceMode2D.Impulse);
    }
    public void Enable_Trampoline()
    {
        _trampoline = true;
    }
}
