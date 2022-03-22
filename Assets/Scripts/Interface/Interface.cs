using UnityEngine;
using UnityEngine.UI;
using System;

public class Interface : MonoBehaviour
{
    [SerializeField] protected Engine engine;
    public Image curtain;
    public Transform canvas;
    public Inventory inventory;
    public Spellbook spellBook;
    public CanvasGroup interfacePanel;
    public ChoicePanel choicePanel;
    public CanvasGroup eyeOfHassle;
    public static Interface current;
    [SerializeField] private GameObject _tutorScreen;

    private void Awake()
    {
        current = this;
    }

    public void Show_Tutor()
    {
        Engine.current.playerController.Change_Controls<HelpHandler>();
        _tutorScreen.SetActive(true);
    }

    public void Hide_Tutor()
    {
        Engine.current.playerController.Change_Controls<DefaultHandler>();
        _tutorScreen.SetActive(false);
    }

    public void Spawn_UI_Object(GameObject prefab)
    {
        Instantiate(prefab, canvas);
    }

    public void Enable_Interface(bool enable)
    {
        interfacePanel.alpha = Convert.ToInt32(enable);
        interfacePanel.interactable = enable;
        interfacePanel.blocksRaycasts = enable;
    }
}
