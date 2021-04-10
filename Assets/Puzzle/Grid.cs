using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    [SerializeField] private float size = 1f;
    public float Size { get { return size; } }

    private void Start()
    {
        for (int x = 0; x < 9; x++)
        {
            for (int z = 0; z < 6; z++)
            {
                //var point = GetNearestPointOnGrid(new Vector3(x, z, 0f));
                //Instantiate(GameObject.CreatePrimitive(PrimitiveType.Cube), new Vector3(x, z, 0f), Quaternion.identity);
            }
        }
    }

    public Vector3 GetNearestPointOnGrid(Vector3 position)
    {
        position -= transform.position;

        int xCount = Mathf.RoundToInt(position.x / size);
        int yCount = Mathf.RoundToInt(position.y / size);
        int zCount = Mathf.RoundToInt(position.z / size);

        //Debug.Log(xCount);
        //Debug.Log(yCount);
        //Debug.Log(zCount);
        //Vector3 result = new Vector3(0.9f, 0.6f, 0.4f);
        Vector3 result = new Vector3((float)xCount * size, (float)yCount * size, (float)zCount * size);
        result += transform.position;
        return result;
    }

    //private void OnDrawGizmos()
    //{
    //    Gizmos.color = Color.yellow;
    //    for (int x = 0; x < 9; x++)
    //    {
    //        for (int z = 0; z < 6; z++)
    //        {
    //            var point = GetNearestPointOnGrid(new Vector3(x, z, 0f));
    //            Gizmos.DrawSphere(point, 0.2f);
    //        }
    //    }
    //}
}
