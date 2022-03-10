
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour, IPlayerIndicator
{
    public float speed;
    public float jumpForce;
    public Rigidbody2D fairyAnchor;
    public SpriteRenderer _indicator;
    public Transform firePoint;
    public Transform spellDirection;
    public Animator animator;
    public Rigidbody2D rb { get; private set; }
    public bool isGround { get; private set; }
    public float checkRadius;
    public LayerMask whatIsGround;

    public Collider2D Collider { get; set; }



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
        Collider = GetComponent<Collider2D>();
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

    public void Move(int direction, bool run)
    {
        float _currentSpeed = run ? speed * 3 : speed;
        rb.velocity = new Vector2(direction * _currentSpeed, rb.velocity.y);
    }

    public void Change_Controls<T>() where T : ControlHandler, new()
    {
        buttonsControl = new T();
    }

    public void Die()
    {
        Engine.current.Last_Chekpoint();
    }

    public void Set_Indicator(Sprite indicator)
    {
        _indicator.sprite = indicator;
    }

    public void Hide_Indicator()
    {
        Color indicatorColor = _indicator.color;
        indicatorColor.a = 0;
        _indicator.color = indicatorColor;
    }

    public void Show_Indicator()
    {
        Color indicatorColor = _indicator.color;
        indicatorColor.a = 1;
        _indicator.color = indicatorColor;
    }
}
