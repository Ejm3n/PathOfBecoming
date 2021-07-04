using System;

[Serializable]
public class SaveData
{
    public PlayerData playerData;
    public FairyData fairyData;

    public SaveData(PlayerData playerData, FairyData fairyData)
    {
        this.playerData = playerData;
        this.fairyData = fairyData;
    }
}
