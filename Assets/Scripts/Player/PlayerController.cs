using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float jumpForce;

    public float MoveInput;
    private Rigidbody2D rb;

    public bool faceRight = true;
    public bool isGround;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;


    private int extraJump;
    public int ExtraJumpValue;

    [SerializeField] GameObject moveButtons;
    [SerializeField] GameObject firstDiaTrigger;
    [SerializeField] float waitTimeTillStart;
    [SerializeField] Transform pixy;
    [SerializeField] Image rArrow;
    [SerializeField] Image lArrow;
    [SerializeField] Image jumpArrow;
    Color shadowed = new Color(255, 255, 255, 0.1f);
    Color showed = new Color(255, 255, 255, 255);
    private void Start()
    {
        moveButtons.SetActive(false);
        rb = GetComponent<Rigidbody2D>();
        extraJump = ExtraJumpValue;
        if(waitTimeTillStart != 0)
        {
            StartCoroutine(Wait());
        }
       
    }

    private void FixedUpdate()
    {
        isGround = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
         //MoveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(MoveInput * speed, rb.velocity.y);

        if (faceRight == false && MoveInput > 0)
        {
            Flip();           
        }
        else if (faceRight == true && MoveInput < 0)
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
        if(!faceRight)
            pixy.transform.localRotation = Quaternion.Euler(0, 180, 0);
        else if(faceRight)
            pixy.transform.localRotation = Quaternion.Euler(0, 0, 0);
        faceRight = !faceRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }

    private IEnumerator Wait()
    {
        yield return new WaitForSecondsRealtime(waitTimeTillStart);
        firstDiaTrigger.SetActive(true);
    }
    public void OnRightButtonDown()
    {
        MoveInput = 1;
        rArrow.color = showed;
    }
    public void OnLeftButtonDown()
    {
        MoveInput = -1;
        lArrow.color = showed;
    }
    public void OnButtonUp()
    {
        MoveInput = 0;
        rArrow.color = shadowed;
        lArrow.color = shadowed;
        //jumpArrow.color = shadowed;
    }
    public void OnJumpButton()
    {
        if (isGround)
        {
            rb.velocity = Vector2.up * jumpForce;
            jumpArrow.color = showed;
            StartCoroutine(showJumpButton());
        }
            
    }
    private IEnumerator showJumpButton()
    {
        yield return new WaitForSeconds(0.2f);
        jumpArrow.color = shadowed;
    }
}
