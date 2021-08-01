using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Health))]
[RequireComponent(typeof(SpellCast))]
public class PlayerController : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    public Rigidbody2D fairyAnchor;

    public float MoveInput;
    public Rigidbody2D rb { get; private set; }

    public bool faceRight { get; private set; }
    public bool isGround { get; private set; }
    public float checkRadius;
    public LayerMask whatIsGround;

    Health health;

    public Vector3 lastCheckpoint { get; private set; }

    private int extraJump;
    public int ExtraJumpValue;

    public void Initialise(Image healthBar, Button jump)
    {
        health = GetComponent<Health>();
        health.Initialise(healthBar);
        jump.onClick.AddListener(OnJumpButton);
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
        faceRight = true;
    }

    private void FixedUpdate()
    {
        isGround = Physics2D.OverlapCircle(transform.position, checkRadius, whatIsGround);
       
        rb.velocity = new Vector2(Joystick.axisX * speed, rb.velocity.y);

        if (faceRight == false && Joystick.axisX > 0)
        {
            Flip();           
        }
        else if (faceRight == true && Joystick.axisX < 0)
        {
            Flip();           
        }

        if (isGround == true)
        {
            extraJump = ExtraJumpValue;
        }

        if (Input.GetKeyDown(KeyCode.Space) && extraJump > 0)
        {
            rb.velocity = Vector2.up * jumpForce;
            extraJump--;
        }
        else if (Input.GetKeyDown(KeyCode.Space) && extraJump == 0 && isGround == true)
        {
            rb.velocity = Vector2.up * jumpForce;
        }
    }

    public void Flip()
    {
        faceRight = !faceRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
    public void OnRightButtonDown()
    {
        MoveInput = 1;
        
    }
    public void OnLeftButtonDown()
    {
        MoveInput = -1;
        
    }
    public void OnButtonUp()
    {
        MoveInput = 0;
    }
    public void OnJumpButton()
    {
        if (isGround)
            rb.velocity = Vector2.up * jumpForce;
            
    }

    public void Last_Checkpoint()
    {
        Engine.current.Last_Chekpoint(() => health.Heal(health.maxHealth));
    }
}
