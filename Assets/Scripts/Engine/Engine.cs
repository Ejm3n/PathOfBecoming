using UnityEngine;
using System;
using UnityEngine.UI;
using Cinemachine;
using AnimationUtils.ImageUtils;
using UnityEngine.SceneManagement;

public abstract class Engine : MonoBehaviour
{
    public static bool load = false;

    public static Engine current;

    [SerializeField] protected Interface userInterface;
    [SerializeField] protected CinemachineVirtualCamera playerCamera;
    public DialogueSystem dialogueSystem;
    public PuzzleController puzzleController;
    public GameSettings gameSettings;

    [Header("Start Positions")]
    [SerializeField] Transform playerStartPosition;
    [SerializeField] Transform fairyStartPosition;

    [Header("Other")]
    [SerializeField] protected GameObject startDialog;

    protected const float timeToFade = 1f;

    public PlayerController playerController { get; private set; }
    public EyeOfHassle eyeOfHassle { get; private set; }
    protected Fairy fairyController;

    protected Image curtain;

    protected AudioClip mainTheme;
    protected AudioClip ambient;

    public GameObject player { get; protected set; }
    public GameObject fairy { get; protected set; }
    protected abstract void Start_Level();

    protected virtual void Load_Level()
    {
        SaveData data;
        try
        {
            data = SaveSyatem.Load_Data();
        }
        catch (NullReferenceException)
        {
            Start_Level();
            return;
        }
        if (data.playerData.sceneIndex != SceneManager.GetActiveScene().buildIndex)
            Start_Level();
        Spawn_Characters(data.playerData.lastCheckpoint.Convert_to_UnityVector(), data.fairyData.checkPoint.Convert_to_UnityVector());
        playerController.Load_State(data.playerData);
        fairyController.Load_State(data.fairyData);
        userInterface.inventory.LoadInventoryData(data.inventoryData);
        userInterface.spellBook.Load_State(data.spellBookData);
        dialogueSystem.Load_State(data.checkpointIndex);
        Show_Scene(() => dialogueSystem.SetUI(true));
    }

    protected void Spawn_Characters()
    {
        Spawn_Characters(playerStartPosition.position, fairyStartPosition.position);
    }

    protected void Spawn_Characters(Vector3 playerPosition, Vector3 fairyPosition)
    {
        GameObject player = Resources.Load<GameObject>("Prefabs/Characters/Player");
        GameObject fairy = Resources.Load<GameObject>("Prefabs/Characters/Fairy");
        this.player = Instantiate(player, playerPosition, Quaternion.identity);
        this.fairy = Instantiate(fairy, fairyPosition, Quaternion.identity);
        Initialise();
    }

    protected void Spawn_Characters(GameObject player, GameObject fairy)
    {
        Spawn_Characters(player, fairy, playerStartPosition.position, fairyStartPosition.position);
    }

    protected void Spawn_Characters(GameObject player, GameObject fairy, Vector3 playerPosition, Vector3 fairyPosition)
    {
        this.player = Instantiate(player, playerPosition, Quaternion.identity);
        this.fairy = Instantiate(fairy, fairyPosition, Quaternion.identity);
        Initialise();
    }

    void Initialise()
    {
        playerCamera.Follow = player.transform;
        playerController = player.GetComponent<PlayerController>();
        fairyController = fairy.GetComponent<Fairy>();
    }

    protected virtual void Awake()
    {
        current = this;
        curtain = userInterface.curtain;
        SoundRecorder.Play_Music(mainTheme);
        SoundRecorder.Play_Ambient(ambient);
    }

    private void Start()
    {
        gameSettings = SaveSyatem.gameSettings;
        if (!load)
            Start_Level();
        else
            Load_Level();
    }

    public void Checkpoint(int index)
    {
        PlayerData playerData = playerController.Save_State();
        FairyData fairyData = fairyController.Save_State();
        InventoryData inventoryData = userInterface.inventory.SaveInvetnoryData();
        SpellBookData spellBookData = userInterface.spellBook.Save_State();
        new SaveData(index, playerData, fairyData, inventoryData, spellBookData).Save();
    }

    public void Connect_Fairy_to_Player()
    {
        fairyController.Connect_Fairy(playerController.fairyAnchor);
    }

    public void Last_Chekpoint(Action onRespawn = null)
    {
        Hide_Scene(() =>
        {
            player.transform.position = playerController.lastCheckpoint;
            fairy.transform.position = fairyController.lastCheckpoint;
            Show_Scene(onRespawn);
        });
    }

    public void Hide_Scene(Action onComplete = null)
    {
        playerController.Change_Controls<UncontrollableHandler>();
        curtain.gameObject.SetActive(true);
        curtain.Unfade(timeToFade, onComplete);
    }

    public void Show_Scene(Action onComplete = null)
    {
        playerController.Change_Controls<UncontrollableHandler>();
        onComplete += () => curtain.gameObject.SetActive(false);
        onComplete += () => playerController.Change_Controls<DefaultHandler>();
        curtain.Fade(timeToFade, onComplete);
    }

    public void Collect_Eye_Of_Hassle(EyeOfHassle eye)
    {
        eyeOfHassle = eye;
    }

    public void Remove_Eye_Of_Hassle()
    {
        eyeOfHassle = null;
    }

    public void Awake_Eye()
    {
        if (eyeOfHassle)
            eyeOfHassle.Eye_Awaken();
    }

    public void Ensleep_Eye()
    {
        if (eyeOfHassle)
            eyeOfHassle.Eye_Asleep();
    }

    public void Load_Next_Level()
    {
        load = false;
        Hide_Scene(() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1));
    }

    public void Play_Animation(Animation animation)
    {
        animation.Play();
    }
}
