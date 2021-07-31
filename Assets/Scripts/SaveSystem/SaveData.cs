using System;

[Serializable]
public class SaveData
{
    public int checkpointIndex;
    public PlayerData playerData;
    public FairyData fairyData;
    public InventoryData inventoryData;
    public SpellBookData spellBookData;

    public SaveData(int checkpointIndex, PlayerData playerData, FairyData fairyData, InventoryData inventoryData, SpellBookData spellBookData)
    {
        this.checkpointIndex = checkpointIndex;
        this.playerData = playerData;
        this.fairyData = fairyData;
        this.inventoryData = inventoryData;
        this.spellBookData = spellBookData;
    }
}
