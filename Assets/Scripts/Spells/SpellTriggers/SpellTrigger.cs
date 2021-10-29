using System;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider2D))]
public class SpellTrigger : MonoBehaviour
{
    [SerializeField] SpellExecution[] spellEffects;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Spell_Effect(collision.gameObject.GetComponent<SpellBlast>());
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Spell_Effect(collision.gameObject.GetComponent<SpellBlast>());
        Destroy(collision.gameObject);
    }

    void Spell_Effect(SpellBlast spellBlast)
    {
        foreach (SpellExecution effect in spellEffects)
            if (effect.spellType == spellBlast.spellType)
            {
                effect.execution?.Invoke();
                return;
            }
    }
}

[Serializable]
class SpellExecution
{
    public SpellType spellType;
    public UnityEvent execution;
}
