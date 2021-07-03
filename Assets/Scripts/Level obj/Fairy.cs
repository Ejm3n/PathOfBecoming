using UnityEngine;

public class Fairy : MonoBehaviour
{
    Rigidbody2D rb;
    RelativeJoint2D joint;

    Rigidbody2D connection;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        joint = GetComponent<RelativeJoint2D>();
    }

    public void Connect_Fairy(Rigidbody2D anchor)
    {
        rb.bodyType = RigidbodyType2D.Dynamic;
        joint.connectedBody = anchor;
        connection = anchor;
    }

    private void FixedUpdate()
    {
        if (rb.velocity.x > 0)
            transform.rotation = Quaternion.Euler(0, 180, 0);
        else if (rb.velocity.x < 0)
            transform.rotation = Quaternion.Euler(0, 0, 0);
    }
}
