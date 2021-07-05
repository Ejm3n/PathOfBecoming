using UnityEngine;
using UnityEngine.UI;
using Cinemachine;
using GlobalVariables;

public abstract class Engine : MonoBehaviour
{
    public static bool load = false;

    [SerializeField] protected Image curtain;
    [SerializeField] CinemachineVirtualCamera playerCamera;
    public HintMap hintMap;

    [Header("Player Interface")]
    [SerializeField] protected ActionWithSpellBook spellBook;
    [SerializeField] protected Inventory inventory;
    [SerializeField] ManaCounter mana;
    [SerializeField] Image healthBar;
    [SerializeField] Button jumpButton;

    [Header("Start Positions")]
    [SerializeField] Transform playerStartPosition;
    [SerializeField] Transform fairyStartPosition;

    protected const float timeToFade = 3f;

    protected PlayerController playerController;
    protected Fairy fairyController;

    public GameObject player { get; protected set; }
    public GameObject fairy { get; protected set; }
    protected abstract void LoadLevel();
    protected abstract void Start_Level();

    protected void Spawn_Characters()
    {
        player = Instantiate(Prefabs.PLAYER, playerStartPosition.position, playerStartPosition.rotation, transform);
        fairy = Instantiate(Prefabs.FAIRY, fairyStartPosition.position, fairyStartPosition.rotation, transform);
        Initialise();
    }

    protected void Spawn_Characters(Vector3 playerPosition, Vector3 fairyPosition)
    {
        player = Instantiate(Prefabs.PLAYER, playerPosition, Quaternion.identity, transform);
        fairy = Instantiate(Prefabs.FAIRY, fairyPosition, Quaternion.identity, transform);
        Initialise();
    }

    void Initialise()
    {
        playerCamera.Follow = player.transform;
        playerController = player.GetComponent<PlayerController>();
        fairyController = fairy.GetComponent<Fairy>();
        playerController.Initialise(this, spellBook, mana, healthBar, jumpButton);
    }

    private void Awake()
    {
        if (!load)
            Start_Level();
        else
            LoadLevel();
    }

    public void Checkpoint()
    {
        PlayerData playerData = playerController.Save_State();
        FairyData fairyData = fairyController.Save_State();
        InventoryData inventoryData = inventory.SaveInvetnoryData();
        MagicBookData magicBookData = spellBook.SaveBookData();
        SaveSyatem.Save(new SaveData(playerData, fairyData, inventoryData, magicBookData));
    }

    public void Connect_Fairy()
    {
        fairyController.Connect_Fairy(playerController.fairyAnchor);
    }
}
