using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    public Vector2Int size = Vector2Int.one;
    public GameObject panel;
    Vector2 panelScale;

    private void Start()
    {
        panelScale = new Vector2(panel.transform.localScale.x, panel.transform.localScale.y);
    }

    private void OnDrawGizmosSelected()
    {
        for (int x = 0; x < size.x; x++)
        {
            for (int y = 0; y < size.y; y++)
            {
                Gizmos.color = Color.red;
                Gizmos.DrawCube(transform.position + new Vector3(x, y, 0), new Vector3(panelScale.x, panelScale.y, 0.1f));
            }
        }
    }
}
