using System;

[Serializable]
public class SaveData
{
    public PlayerData playerData;
    public FairyData fairyData;
    public InventoryData inventoryData;
    public MagicBookData magicBookData;

    public SaveData(PlayerData playerData, FairyData fairyData, InventoryData inventoryData, MagicBookData magicBookData)
    {
        this.playerData = playerData;
        this.fairyData = fairyData;
        this.inventoryData = inventoryData;
        this.magicBookData = magicBookData;
    }
}
