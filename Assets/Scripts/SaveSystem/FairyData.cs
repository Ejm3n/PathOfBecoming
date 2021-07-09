using System;

[Serializable]
public class FairyData
{
    public Vector3Serial checkPoint;
    public bool connected;

    public FairyData(Vector3Serial checkPoint)
    {
        this.checkPoint = checkPoint;
    }
}
