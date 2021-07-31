using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spellbook : MonoBehaviour
{
    [SerializeField] Animator slotsAnim;

    [SerializeField] private Sprite openBook;
    [SerializeField] private Sprite closedBook;
    [SerializeField] private Button book;

    public Transform[] slots;
    CanvasGroup spellBookCG;

    List<Spell> spellList = new List<Spell>();

    public Spell chosenSpell { get; private set; }

    bool shown = false;

    private void Start()
    {
        spellBookCG = GetComponent<CanvasGroup>();
    }

    public void ShowSlots()
    {
        shown = !shown;
        Spell_Animation(-1);
        slotsAnim.SetBool("SlotsShown", shown);
        if (shown)
            book.image.sprite = openBook;
        else
            book.image.sprite = closedBook;

    }

    public void Learn_Spell(GameObject prefab)
    {
        Spell spell = Instantiate(prefab, slots[spellList.Count]).GetComponent<Spell>();
        spellList.Add(spell);
    }

    public void Choose_Spell(Spell spell)
    {
        int index = spellList.IndexOf(spell);
        chosenSpell = spell;
        Spell_Animation(index, true);
    }

    public void Spell_Used(Spell spell)
    {
        int index = spellList.IndexOf(spell);
        chosenSpell = null;
        Spell_Animation(index, false);
    }

    public void Cast_Chosen_Spell(Transform firePoint)
    {
        if (!chosenSpell || !Interface.current.mana.SpellShot(chosenSpell.manaCost))
            return;
        chosenSpell.Cast(firePoint);
    }

    void Spell_Animation(int index, bool state = false)
    {
        switch (index)
        {
            case 0:
                slotsAnim.SetBool("ChooseSpellOne", state);
                break;
            case 1:
                slotsAnim.SetBool("ShooseSpellTwo", state);
                break;
            case 2:
                slotsAnim.SetBool("ShooseSpellThree", state);
                break;
            default:
                slotsAnim.SetBool("ChooseSpellOne", state);
                slotsAnim.SetBool("ShooseSpellTwo", state);
                slotsAnim.SetBool("ShooseSpellThree", state);
                break;
        }
    }

    public void Enable_Spellbook()
    {
        spellBookCG.alpha = 1;
        spellBookCG.blocksRaycasts = true;
        spellBookCG.interactable = true;
        Engine.current.dialogueSystem.canUseSpellBook = true;
    }

    public void Load_State(SpellBookData data)
    {
        for (int i = 0; i < data.spellNames.Length; i++)
        {
            GameObject prefab = Resources.Load<GameObject>(Spell.path + data.spellNames[i]);
            Learn_Spell(prefab);
        }
    }

    public SpellBookData Save_State()
    {
        string[] data = new string[spellList.Count];
        for (int i = 0; i < data.Length; i++)
            data[i] = spellList[i].name;
        return new SpellBookData(data);
    }
}
