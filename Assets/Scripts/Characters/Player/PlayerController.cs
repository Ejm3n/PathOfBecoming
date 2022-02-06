
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    public Rigidbody2D fairyAnchor;
    public SpriteRenderer interactIndicator;
    public Transform firePoint;
    public Transform spellDirection;

    public Rigidbody2D rb { get; private set; }
    public bool isGround { get; private set; }
    public float checkRadius;
    public LayerMask whatIsGround;

    public ControlHandler buttonsControl { get; private set; }

    public Vector3 lastCheckpoint { get; private set; }

    private int extraJump;
    public int ExtraJumpValue;

    public void Initialise()
    {
        return;
    }
    public void Load_State(PlayerData data)
    {
        transform.position = data.lastCheckpoint.Convert_to_UnityVector();
        lastCheckpoint = transform.position;
    }

    public PlayerData Save_State()
    {
        lastCheckpoint = transform.position;
        return new PlayerData(SceneManager.GetActiveScene().buildIndex, new Vector3Serial(transform.position));
    }

    private void Awake()
    {
        isGround = Physics2D.OverlapCircle(transform.position, checkRadius, whatIsGround);
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        extraJump = ExtraJumpValue;
        lastCheckpoint = transform.position;
    }

    public void Jump()
    {
        if (isGround == true)
            extraJump = ExtraJumpValue;
        if (extraJump > 0)
        {
            rb.velocity = Vector2.up * jumpForce;
            extraJump--;
        }
        else if (extraJump == 0 && isGround == true)
        {
            rb.velocity = Vector2.up * jumpForce;
        }
    }

    private void Update()
    {
        buttonsControl.Action();
        isGround = Physics2D.OverlapCircle(transform.position, checkRadius, whatIsGround);
    }

    public void Move(int direction)
    {
        rb.velocity = new Vector2(direction * speed, rb.velocity.y);
    }

    public void Change_Controls<T>() where T : ControlHandler, new()
    {
        buttonsControl = new T();
    }

    public void Die()
    {
        Engine.current.Last_Chekpoint();
    }
}
