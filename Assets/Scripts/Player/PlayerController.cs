using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Health))]
[RequireComponent(typeof(ShootingSpells))]
public class PlayerController : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    public Rigidbody2D fairyAnchor;

    public float MoveInput;
    private Rigidbody2D rb;

    public bool faceRight { get; private set; }
    public bool isGround { get; private set; }
    public Engine engine { get; private set; }
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    Health health;
    ShootingSpells spellFire;

    private int extraJump;
    public int ExtraJumpValue;

    public void Initialise(Engine engine, ActionWithSpellBook spellBook, ManaCounter mana, Image healthBar, Button jump)
    {
        this.engine = engine;
        health = GetComponent<Health>();
        spellFire = GetComponent<ShootingSpells>();
        health.Initialise(healthBar);
        spellFire.Initialise(spellBook, mana);
        jump.onClick.AddListener(OnJumpButton);
    }

    public void Load_State(PlayerData data)
    {
        health.Set_Health(data.hp);
        transform.position = data.lastCheckpoint.Convert_to_UnityVector();
    }

    public PlayerData Save_State()
    {
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
        isGround = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
       
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
        {
            rb.velocity = Vector2.up * jumpForce;

            //StartCoroutine(showJumpButton());
        }
            
    }
    private IEnumerator showJumpButton()
    {
        yield return new WaitForSeconds(0.2f);

    }
}
