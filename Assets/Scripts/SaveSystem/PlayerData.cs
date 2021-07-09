using System;

[Serializable]
public class PlayerData
{
    public int sceneIndex;
    public Vector3Serial lastCheckpoint;
    public float hp;

    public PlayerData(int sceneIndex, Vector3Serial lastCheckpoint, float hp)
    {
        this.sceneIndex = sceneIndex;
        this.lastCheckpoint = lastCheckpoint;
        this.hp = hp;
    }
}
