using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snap : MonoBehaviour
{
    [SerializeField] private Vector2 gridSize;
    Vector2 position;

    private void OnDrawGizmos()
    {
        SnapToGrid();
    }

    private void SnapToGrid()
    {
        if (gameObject.CompareTag("Horizontal"))
        {
            position = new Vector2(
            Mathf.RoundToInt(this.transform.position.x / 2) * 2,
            Mathf.RoundToInt(this.transform.position.y)
            );
        }
        if (gameObject.CompareTag("Vertical"))
        {
            position = new Vector2(
            Mathf.RoundToInt(this.transform.position.x),
            Mathf.RoundToInt(this.transform.position.y / 2) * 2
            );
        }
        

        this.transform.position = position;
    }
}
