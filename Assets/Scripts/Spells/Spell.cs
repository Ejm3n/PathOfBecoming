using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class Spell : MonoBehaviour, IPointerDownHandler
{
    //Spell in spellbook
    public float manaCost;
    public SpellType spellType;
    public float cooldown;

    public GameObject projectile;

    public const string path = "Prefabs/Magic/Spells/";

    bool onCooldown = false;

    public void Cast(Vector3 firePoint, bool alternative)
    {   if (onCooldown || !Interface.current.mana.SpellShot(manaCost))
            return;
        Instantiate(projectile, firePoint, Quaternion.identity);
        StartCoroutine(Cooldown());
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Interface.current.spellBook.Choose_Spell(this);
    }

    IEnumerator Cooldown()
    {
        onCooldown = true;
        Interface.current.spellBook.Spell_Used(this);
        yield return new WaitForSeconds(cooldown);
        onCooldown = false;
    }
}

public enum SpellType { Instant, AltInstant, Stream }

