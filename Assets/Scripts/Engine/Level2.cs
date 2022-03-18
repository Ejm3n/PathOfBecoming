using Cinemachine;
using System.Collections;
using UnityEngine;

public class Level2 : Engine
{
    [SerializeField] Transform rocks;
    [SerializeField] Transform fallPoint;

    [SerializeField] GameObject windEmpoweredTrigger;

    [SerializeField] ParticleSystem potParticle;

    [SerializeField] private Transform _rockPlace;
    [SerializeField] private GameObject _rock;

    [SerializeField] private Transform _windmillPlace;
    public bool Stool { get; private set; }

    protected override void Awake()
    {
        Stool = false;
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
        //userInterface.spellBook.Learn_Spell(Resources.Load<GameObject>("Prefabs/Magic/Spells/Lighter(Spell)"));
        //userInterface.inventory.Add_To_Inventory(Resources.Load<GameObject>("Prefabs/Items/Inventory/Potion(Level2)"));
        userInterface.inventory.Add_To_Inventory(Resources.Load<GameObject>("Prefabs/Items/Inventory/EyeOfHassle"));
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

    public void PotEmissionChange(int particles)
    {
        ParticleSystem.EmissionModule em = potParticle.emission;
        em.rateOverTimeMultiplier += particles;
    }

    public void Throw_Rock()
    {
        playerController.Change_Controls<UncontrollableHandler>();
        playerController.animator.SetTrigger("Throw");
    }

    public void Spawn_Rock()
    {
        playerController.Change_Controls<DefaultHandler>();
        Instantiate(_rock, _rockPlace);
    }
    public void WindmillGo()
    {
        Hide_Scene(() => StartCoroutine(Unfade()));
    }
    IEnumerator Unfade()
    {
        player.transform.position = _windmillPlace.position;
        playerController.Change_Controls<UncontrollableHandler>();
        fairy.transform.position = _windmillPlace.position;
        yield return new WaitForSeconds(0.5f);
        Show_Scene();
    }
    public void ChangePlayerAnimatorToJumpAnim()
    {
        playerController.animator.SetTrigger("StoolJump");
    }
}
