using UnityEngine;
using System;

[Serializable]
public class FairyData
{
    public Vector3Serial checkPoint;
    public bool connected;

    public FairyData(Vector3Serial checkPoint, bool connected)
    {
        this.checkPoint = checkPoint;
        this.connected = connected;
    }
}
