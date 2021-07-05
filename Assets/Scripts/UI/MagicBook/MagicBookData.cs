using System;

[Serializable]
public class MagicBookData
{
    public bool[] EnabledSpells ;      

    public MagicBookData()
    {
        EnabledSpells = MagicBookSave.whichSpellIsActive;
    }
}
