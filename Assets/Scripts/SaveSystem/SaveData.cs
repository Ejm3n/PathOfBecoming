using System;

[Serializable]
public class SaveData
{
    public int[] checkpoints;
    public PlayerData playerData;
    public FairyData fairyData;
    public InventoryData inventoryData;
    public SpellBookData spellBookData;

    public SaveData(int[] checkpoints, PlayerData playerData, FairyData fairyData, InventoryData inventoryData, SpellBookData spellBookData)
    {
        this.checkpoints = checkpoints;
        this.playerData = playerData;
        this.fairyData = fairyData;
        this.inventoryData = inventoryData;
        this.spellBookData = spellBookData;
    }
}
