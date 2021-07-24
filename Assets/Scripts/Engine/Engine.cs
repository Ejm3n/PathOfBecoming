﻿using UnityEngine;
using System;
using UnityEngine.UI;
using Cinemachine;
using GlobalVariables;
using AnimationUtils.ImageUtils;
using UnityEngine.SceneManagement;

public abstract class Engine : MonoBehaviour
{
    public static bool load = false;

    [SerializeField] protected Image curtain;
    [SerializeField] CinemachineVirtualCamera playerCamera;
    [SerializeField] protected DialogueSystem dialogueSystem;
    public GameSettings gameSettings;

    [Header("Player Interface")]
    [SerializeField] protected ActionWithSpellBook spellBook;
    [SerializeField] protected Inventory inventory;
    [SerializeField] ManaCounter mana;
    [SerializeField] Image healthBar;
    [SerializeField] Button jumpButton;

    [Header("Start Positions")]
    [SerializeField] Transform playerStartPosition;
    [SerializeField] Transform fairyStartPosition;

    protected const float timeToFade = 1f;

    protected PlayerController playerController;
    protected Fairy fairyController;

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
            if (data.playerData.sceneIndex != SceneManager.GetActiveScene().buildIndex)
                Start_Level();
            Spawn_Characters(data.playerData.lastCheckpoint.Convert_to_UnityVector(), data.fairyData.checkPoint.Convert_to_UnityVector());
            playerController.Load_State(data.playerData);
            fairyController.Load_State(data.fairyData);
            inventory.LoadInventoryData(data.inventoryData);
            //spellBook.LoadBookData(data.magicBookData);
            dialogueSystem.Load_State(data.checkpointIndex);
            Show_Scene(() => dialogueSystem.SetUI(true));
        }
        catch (NullReferenceException)
        {
            Start_Level();
        }
    }

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
        InventoryData inventoryData = inventory.SaveInvetnoryData();
        MagicBookData magicBookData = spellBook.SaveBookData();
        new SaveData(index, playerData, fairyData, inventoryData, magicBookData).Save();
    }

    public void Connect_Fairy_to_Player()
    {
        fairyController.Connect_Fairy(playerController.fairyAnchor);
    }

    public void Last_Chekpoint(Action onRespawn)
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
        curtain.gameObject.SetActive(true);
        curtain.Unfade(timeToFade, onComplete);
    }

    public void Show_Scene(Action onComplete = null)
    {
        onComplete += () => curtain.gameObject.SetActive(false);
        curtain.Fade(timeToFade, onComplete);
    }
}
