using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicBookData : MonoBehaviour
{
    public bool[] EnabledSpells ;      

    public MagicBookData()
    {
        EnabledSpells = MagicBookSave.whichSpellIsActive;
    }
}
