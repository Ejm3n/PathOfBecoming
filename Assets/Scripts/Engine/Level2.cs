
using System.Collections;
using UnityEngine;

public class Level2 : Engine
{
    [SerializeField] Transform rocks;
    [SerializeField] Transform fallPoint;

    [SerializeField] GameObject windEmpoweredTrigger;
    protected override void Awake()
    {
        mainTheme = Resources.Load<AudioClip>("Sounds/Music/Level2");
        base.Awake();
    }

    protected override void Start_Level()
    {
        GameObject player = Resources.Load<GameObject>("Prefabs/Characters/Player");
        GameObject fairy = Resources.Load<GameObject>("Prefabs/Characters/Fairy");
        Spawn_Characters(player, fairy);
        Connect_Fairy_to_Player();
        userInterface.spellBook.Learn_Spell(Resources.Load<GameObject>("Prefabs/Magic/Spells/Whirlwind(Spell)"));
        userInterface.spellBook.Learn_Spell(Resources.Load<GameObject>("Prefabs/Magic/Spells/Lighter(Spell)"));
        Show_Scene(() => {
            userInterface.inventory.Enable_Inventory();
            userInterface.spellBook.Enable_Spellbook();
            userInterface.Enable_Interface(true);
            startDialog.SetActive(true);
        });
    }

    public void Rock_Fall()
    {
        rocks.position = fallPoint.position;
    }

    public void Empowered_Blow()
    {
        StartCoroutine(Timed_Enable());
    }

    IEnumerator Timed_Enable()
    {
        windEmpoweredTrigger.SetActive(true);
        yield return new WaitForSeconds(2);
        windEmpoweredTrigger.SetActive(false);
    }

}
