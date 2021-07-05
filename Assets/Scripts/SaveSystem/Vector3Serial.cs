using System;
using UnityEngine;

[Serializable]
public class Vector3Serial
{
    public float x;
    public float y;
    public float z;

    public Vector3Serial(Vector3 unityVector)
    {
        x = unityVector.x;
        y = unityVector.y;
        z = unityVector.z;
    }

    public Vector3 Convert_to_UnityVector()
    {
        return new Vector3(x, y, z);
    }
}
