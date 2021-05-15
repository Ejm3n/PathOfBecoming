using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
public class Brick : MonoBehaviour
{
    public Orientation orientation;
    public float powerMultiplier;
    public Puzzle controller;

    Rigidbody2D brick;
    Camera mainCam;

    private void Start()
    {
        mainCam = Camera.main;
        brick = GetComponent<Rigidbody2D>();
        if (orientation == Orientation.X)
            brick.constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
        else if (orientation == Orientation.Y)
            brick.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
        else
            brick.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    public enum Orientation
    {
        X = 0,
        Y = 1,
        XY = 2
    };

    void Win_Condition()
    {
        controller.Solve_Puzzle();
    }

    private void OnMouseDown()
    {
        Vector3 power = mainCam.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        brick.AddForce(power * powerMultiplier * brick.mass);
    }

    private void OnMouseDrag()
    {
        Vector3 power = mainCam.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        brick.AddForce(power * powerMultiplier * brick.mass);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Win_Condition();
    }
}
