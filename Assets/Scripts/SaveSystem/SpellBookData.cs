using System;

[Serializable]
public class SpellBookData
{
    public string[] spellNames;

    public SpellBookData(string[] spellNames)
    {
        this.spellNames = spellNames;
    }
}
