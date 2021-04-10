using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueSystem : MonoBehaviour
{
    [SerializeField] Text output;
    [SerializeField] Text nameOutput;
    [SerializeField] Text choice1Text;
    [SerializeField] Text choice2Text;
    [SerializeField] GameObject choiceNextTrigger;
    [SerializeField] GameObject controlButtons;
    [SerializeField] GameObject manaBar;
    [SerializeField] GameObject inventory;
    [SerializeField] GameObject spellBook;
    [SerializeField] PlayerController PC;
    [SerializeField] Animator panelAnim;
    [SerializeField] Animator choosePanelAnim;
    [SerializeField] Image dialogueImg;
    [SerializeField] Sprite henryImg;
    [SerializeField] Sprite fairyImg;
    [SerializeField] Sprite impImg;

    public string[] file;
    private int whereIsEndChoose;
    private int choice1;
    private int choice2;
    private string subPlayer = "player";
    private string subFairy = "fairy";
    private string subImp = "imp";
    private string subCat = "cat";
    private string subAnonim = "anonym";
    private string subStranger = "stranger";
    private bool dialogueStarted;
    private bool next;
    private bool canUseInventory = false;
    private bool canUseSpellBook = false;
    Queue<string> linesTriggered = new Queue<string>();

    

    private void Awake()
    {
        next = false;
        dialogueStarted = false;      
        TextAsset language = Resources.Load<TextAsset>("Russian2");
        file = language.text.Split('\n');     
    }
    private void Update()
    {
        if (dialogueStarted && next)
        {
            DisplayNextLine();
            next = false;
        }
    }
    
    public void Next()
    {
        next = true;
    }
    private void SetUI(bool what)
    {
        //if(canUseInventory)
        //{
        //    inventory.SetActive(what);
        //}
        //if(canUseSpellBook)
        //{
        //    inventory.SetActive(what);
        //}
        controlButtons.SetActive(what);
        manaBar.SetActive(what);
    }
    public void ChooseStart(int choose1, int choose2,int endOfChoices,GameObject nextTrigger)
    {
        SetUI(false);
        PC.OnButtonUp();
        choice1Text.text = file[choose1].Substring(file[choose1].IndexOf('=') + 1); ;
        choice2Text.text = file[choose2].Substring(file[choose2].IndexOf('=') + 1); ;
        choosePanelAnim.SetBool("PanelShow", true);
        whereIsEndChoose = endOfChoices;
        choice1 = choose1;
        choice2 = choose2;
        choiceNextTrigger = nextTrigger;
    }
    public void OnChoice1Click()
    {
        choosePanelAnim.SetBool("PanelShow", false);       
        StartDialogue(choice1, choice2, choiceNextTrigger);
    }
    public void OnChoice2Click()
    {
        choosePanelAnim.SetBool("PanelShow", false);
        StartDialogue(choice2, whereIsEndChoose, choiceNextTrigger);
    }
    public void StartDialogue(int startLine, int endLine, GameObject nextTrigger)
    {
        if(endLine == 30)//следущие 2 ифа надо както покруче сделать но щас поздно мне лень
        {
            canUseInventory = true;
        }
        if(endLine == 53)
        {
            canUseSpellBook = true;
        }
        choiceNextTrigger = nextTrigger;
        panelAnim.SetBool("PanelShow", true);
        dialogueStarted = true;
        SetUI(false);
        PC.OnButtonUp();
        for (int i = startLine; i < endLine; i++)
        {
            linesTriggered.Enqueue(file[i]);
        }
        DisplayNextLine();
    }
    public void DisplayNextLine()
    {
        if(linesTriggered.Count == 0)
        {
            EndDialogue();
            return;
        }
        string line = linesTriggered.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeLine(line));
    }

    IEnumerator TypeLine(string sentence)
    {
        if(sentence.Contains(subPlayer))
        {
            dialogueImg.color = new Color(255, 255, 255);
            nameOutput.text = "Генри";
            dialogueImg.sprite = henryImg;

        }
        else if (sentence.Contains(subStranger))
        {
            dialogueImg.color = new Color(255, 255, 255);
            nameOutput.text = "???";
            if (sentence.Contains(subFairy))
            {
                dialogueImg.sprite = fairyImg;
            }               
            else if (sentence.Contains(subImp))
            {
                dialogueImg.sprite = impImg;
            }               
        }
        else if (sentence.Contains(subFairy))
        {
            dialogueImg.color = new Color(255, 255, 255);
            nameOutput.text = "Лилия";
            dialogueImg.sprite = fairyImg;
        }
        else if (sentence.Contains(subImp))
        {
            dialogueImg.color = new Color(255, 255, 255);
            nameOutput.text = "Анчутка";
            dialogueImg.sprite = impImg;
        }
        else if(sentence.Contains(subCat))
        {
            nameOutput.text = "Кот";
        }
        else if(sentence.Contains(subAnonim))
        {
            nameOutput.text = "???";
            dialogueImg.sprite = fairyImg;
            dialogueImg.color = new Color(0,0,0);
        }
        

        string result = sentence.Substring(sentence.IndexOf('=') + 1);
        sentence = result.Trim();
        output.text = "";
        foreach(char letter in sentence.ToCharArray())
        {
            yield return new WaitForSecondsRealtime(0.06f);
            output.text += letter;
        }
    }   
    public void EndDialogue()
    {
        choiceNextTrigger.SetActive(true);
        panelAnim.SetBool("PanelShow", false) ;
        dialogueStarted = false;
        SetUI(true);
    }
}