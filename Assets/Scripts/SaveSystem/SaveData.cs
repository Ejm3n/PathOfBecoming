using System;

[Serializable]
public class SaveData
{
    public int checkpointIndex;
    public PlayerData playerData;
    public FairyData fairyData;
    public InventoryData inventoryData;
    public MagicBookData magicBookData;

    public SaveData(int checkpointIndex, PlayerData playerData, FairyData fairyData, InventoryData inventoryData, MagicBookData magicBookData)
    {
        this.checkpointIndex = checkpointIndex;
        this.playerData = playerData;
        this.fairyData = fairyData;
        this.inventoryData = inventoryData;
        this.magicBookData = magicBookData;
    }
}
