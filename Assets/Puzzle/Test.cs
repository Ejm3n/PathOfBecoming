using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public GameObject plane;
    private Vector2 planeSize;
    private RectTransform rectTransform;
    public Sprite sprite;
    public int[,] grid;
    int vertical, horizontal, columns, rows;
    int xPos;
    int yPos;

    void Start()
    {
        xPos = Mathf.RoundToInt(transform.position.x);
        yPos = Mathf.RoundToInt(transform.position.y);

        //vertical = (int)Camera.main.orthographicSize;
        planeSize = plane.GetComponent<RectTransform>().sizeDelta;
        //Debug.Log(planeSize);
        vertical = Mathf.RoundToInt(planeSize.y);
        Debug.Log(vertical);
        horizontal = (vertical * ((int)planeSize.x / (int)planeSize.y));
        
        //horizontal = vertical * (Screen.width / Screen.height);

        columns = horizontal * 2;
        rows = vertical * 2;
        grid = new int[columns, rows];

        for (int i = 0; i < 9; i++)
        {
            for (int j = 0; j < 6; j++)
            {
                grid[i, j] = Random.Range(0, 10);
                SpawnTile(i, j, grid[i, j]);
            }
        }
    }

    private void SpawnTile(int x, int y, int value)
    {
        GameObject go = new GameObject();
        go.transform.position = new Vector2 (x - (horizontal - 0.5f), y - (vertical - 0.5f));
        go.AddComponent<SpriteRenderer>();
        var s = go.GetComponent<SpriteRenderer>();
        s.sprite = sprite;
        s.color = new Color(value, value, value);
    }
}
