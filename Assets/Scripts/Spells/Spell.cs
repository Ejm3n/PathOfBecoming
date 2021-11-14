using System.Collections;
using UnityEngine;

public class Spell : MonoBehaviour
{
    //Spell in spellbook
    public float manaCost;
    public SpellType spellType;
    public float cooldown;

    public GameObject projectile;
    public GameObject altProjectile;

    public const string path = "Prefabs/Magic/Spells/";

    bool onCooldown = false;

    public void Cast(Vector3 firePoint, bool alternative)
    {   
        if (onCooldown || !Interface.current.mana.SpellShot(manaCost))
            return;
        if (alternative && altProjectile)
            Instantiate(altProjectile, firePoint, Quaternion.identity);
        else
            Instantiate(projectile, firePoint, Quaternion.identity);
        StartCoroutine(Cooldown());
    }

    IEnumerator Cooldown()
    {
        onCooldown = true;
        yield return new WaitForSeconds(cooldown);
        onCooldown = false;
    }
}

public enum SpellType { Instant, AltInstant, Stream }

