using UnityEngine;
using Settings;
using System.Collections;

public class SpellCast : MonoBehaviour
{
    [SerializeField] Transform firePoint;

    bool casting = false;
    const float altCast = 0.5f; 

    private void Update()
    {
        if (!ControlButtons.USESPELL || casting || !Interface.current.spellBook.chosenSpell)
            return;
        StartCoroutine(Prepare_Cast());
    }

    IEnumerator Prepare_Cast()
    {
        casting = true;
        ControlButtons.ENABLE_MOVEMENT = false;

        switch (Interface.current.spellBook.chosenSpell.spellType)
        {
            case SpellType.AltInstant:
                float timeStart = Time.time;
                while (ControlButtons.USESPELLHOLD)
                    yield return null;
                Interface.current.spellBook.Cast_Chosen_Spell(firePoint.position, Time.time - timeStart > altCast);
                break;

            default:
                Interface.current.spellBook.Cast_Chosen_Spell(firePoint.position);
                break;
        }

        casting = false;
        ControlButtons.ENABLE_MOVEMENT = true;
    }
}
