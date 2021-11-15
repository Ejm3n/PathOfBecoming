using System.Collections;
using UnityEngine;

public class Spell : MonoBehaviour
{
    //Spell in spellbook
    public float manaCost;
    public SpellType spellType;
    public float cooldown;

    public GameObject projectile;

    public const string path = "Prefabs/Magic/Spells/";

    bool onCooldown = false;

    public void Cast(Vector3 firePoint, float angle)
    {   
        if (onCooldown || !Interface.current.mana.SpellShot(manaCost))
            return;
        Instantiate(projectile, firePoint, Quaternion.Euler(0,Engine.current.player.transform.rotation.eulerAngles.y, angle));
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

