﻿
using UnityEngine;
using PlayerControls;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Health))]
[RequireComponent(typeof(SpellCast))]
public class PlayerController : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    public Rigidbody2D fairyAnchor;
    public SpriteRenderer interactIndicator;

    public Rigidbody2D rb { get; private set; }
    public bool isGround { get; private set; }
    public float checkRadius;
    public LayerMask whatIsGround;

    Health health;

    public Vector3 lastCheckpoint { get; private set; }

    private int extraJump;
    public int ExtraJumpValue;

    public void Initialise(Image healthBar)
    {
        health = GetComponent<Health>();
        health.Initialise(healthBar);
    }
    public void Load_State(PlayerData data)
    {
        health.Set_Health(data.hp);
        transform.position = data.lastCheckpoint.Convert_to_UnityVector();
        lastCheckpoint = transform.position;
    }

    public PlayerData Save_State()
    {
        lastCheckpoint = transform.position;
        return new PlayerData(SceneManager.GetActiveScene().buildIndex, new Vector3Serial(transform.position), health.Get_Health());
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        extraJump = ExtraJumpValue;
        lastCheckpoint = transform.position;
    }

    private void FixedUpdate()
    {
        isGround = Physics2D.OverlapCircle(transform.position, checkRadius, whatIsGround);
       
        rb.velocity = new Vector2(ControlButtonsAxis.xAxisRaw * speed, rb.velocity.y);

        if (isGround == true)
        {
            extraJump = ExtraJumpValue;
        }

        if (ControlButtonsHold.UP && extraJump > 0)
        {
            rb.velocity = Vector2.up * jumpForce;
            extraJump--;
        }
        else if (ControlButtonsAxis.yAxisRaw > 0 && extraJump == 0 && isGround == true)
        {
            rb.velocity = Vector2.up * jumpForce;
        }
    }

    public void Last_Checkpoint()
    {
        Engine.current.Last_Chekpoint(() => health.Heal(health.maxHealth));
    }
}
