using UnityEngine;

public class Fairy : MonoBehaviour, IPlayerIndicator
{
    [SerializeField] private SpriteRenderer _indicator;
    [SerializeField] private float _speed;

    public Collider2D Collider { get; set; }

    public Rigidbody2D rb { get; private set; }
    RelativeJoint2D joint;
    public Vector3 lastCheckpoint { get; private set; }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        joint = GetComponent<RelativeJoint2D>();
        lastCheckpoint = transform.position;
        Collider = GetComponent<Collider2D>();
    }

    public void Connect_Fairy(Rigidbody2D anchor)
    {
        rb.bodyType = RigidbodyType2D.Dynamic;
        joint.enabled = true;
        joint.connectedBody = anchor;
    }

    public void Free_Fairy()
    {
        joint.enabled = false;
    }

    public void Load_State(FairyData data)
    {
        transform.position = data.checkPoint.Convert_to_UnityVector();
        lastCheckpoint = transform.position;
        if (data.connected)
            Engine.current.Connect_Fairy_to_Player();
    }

    public FairyData Save_State()
    {
        lastCheckpoint = transform.position;
        return new FairyData(new Vector3Serial(transform.position));
    }

    private void FixedUpdate()
    {
        if (rb.velocity.x > 0 && transform.rotation.eulerAngles.y == 0)
            transform.rotation = Quaternion.Euler(0, 180, 0);
        else if (rb.velocity.x < 0 && transform.rotation.eulerAngles.y == 180)
            transform.rotation = Quaternion.Euler(0, 0, 0);
    }

    public void Move_Fairy(int directionX, int directionY)
    {
        Vector2 direction = new Vector2(directionX, directionY) * _speed;
        rb.velocity = direction;
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

    public void Set_Indicator(Sprite indicator)
    {
        _indicator.sprite = indicator;
    }
}
