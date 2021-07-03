using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueSystem : MonoBehaviour
{
    [SerializeField] Text output;//ссылка на текст который будет на UI отображаться
    [SerializeField] Text nameOutput;//ссылка на имя которое будет на UI отображаться
    [SerializeField] Text choice1Text;//ссылка на 1 вариант выбора который будет на UI отображаться
    [SerializeField] Text choice2Text;//ссылка на 2 вариант выбора который будет на UI отображаться
    [SerializeField] GameObject controlButtons;//кнопки передвижения, нужны чтоб их отключать во время диалогов
    [SerializeField] GameObject playerBars;//нужен чтоб его отключать во время диалогов
    [SerializeField] CanvasGroup inventory; //нужен чтоб его отключать во время диалогов
    [SerializeField] CanvasGroup spellBook;//нужен чтоб его отключать во время диалогов
    [SerializeField] Animator panelAnim;//анимация панели диалогов
    [SerializeField] Animator choosePanelAnim;// анимация панели выбора диалогов
    [SerializeField] Image dialogueImg;//ссылка на картинку говорящего персонажа
    [SerializeField] Sprite henryImg;//ссылка непосредственно на спрайт игрока
    [SerializeField] Sprite fairyImg;//ссылка непосредственно на спрайт феи
    [SerializeField] Sprite impImg;//ссылка непосредственно на спрайт анчутки
    [SerializeField] CanvasGroup blockingPanel;
    private GameObject choiceNextTrigger;//до куда скипать если выбран 1 вариант

    public string[] file;//все строки файла
    private int whereIsEndChoose;//на какой строчке конец выбора
    private int choice1;//строка с выбором 1
    private int choice2;//строка с выбором 2
    //далее сабстринги для поиска их в файле
    private string subPlayer = "player";
    private string subFairy = "fairy";
    private string subImp = "imp";
    private string subCat = "cat";
    private string subAnonim = "anonym";
    private string subStranger = "stranger";
    public bool canUseInventory = false;//используется ли инвентарь(чтоб его убирать)
    public bool canUseSpellBook = false;//используется ли книга(чтоб ее убирать)
    Queue<string> linesTriggered = new Queue<string>();//очередь строк, которые триггерятся. именно эта очередь будет выводиться на экран
    private bool isDialogueTyping = false;
    private bool typeDialogeInstantly = false;

    

    private void Awake()
    {    
        TextAsset language = Resources.Load<TextAsset>("Russian2");//считываем файл со строками
        file = language.text.Split('\n');     //заполняем этими строками массив
    }
    
    public void Next()//метод для пропуска строчки
    {      
        DisplayNextLine();
    }
    public void SetUI(bool what)//метод отключающий лишний UI
    {
        ChangeCanvasGroup(!what, blockingPanel);
        if (canUseInventory)
        {

            ChangeCanvasGroup(what, inventory);
        }
        if (canUseSpellBook)
        {
            ChangeCanvasGroup(what, spellBook);
        }
        controlButtons.SetActive(what);
        playerBars.SetActive(what);
    }
    private void ChangeCanvasGroup(bool whitch, CanvasGroup cg)//для выключения инвентаря и книгизаклинаний
    {
        if (whitch)
        {
            cg.alpha = 1;
            cg.interactable = true;
            cg.blocksRaycasts = true;
        }
        else
        {
            cg.alpha = 0;
            cg.interactable = false;
            cg.blocksRaycasts = false;
        }
    }
    public void ChooseStart(int choose1, int choose2,int endOfChoices,GameObject nextTrigger)//старт выборных диалогов
    {
        SetUI(false);
        choice1Text.text = file[choose1].Substring(file[choose1].IndexOf('=') + 1); ;
        choice2Text.text = file[choose2].Substring(file[choose2].IndexOf('=') + 1); ;
        choosePanelAnim.SetBool("PanelShow", true);
        whereIsEndChoose = endOfChoices;
        choice1 = choose1;
        choice2 = choose2;
        choiceNextTrigger = nextTrigger;
    }
    public void OnChoice1Click()//выбор 1 нажат
    {
        choosePanelAnim.SetBool("PanelShow", false);       
        StartDialogue(choice1, choice2, choiceNextTrigger);
    }
    public void OnChoice2Click()//выбор 2 нажат
    {
        choosePanelAnim.SetBool("PanelShow", false);
        StartDialogue(choice2, whereIsEndChoose, choiceNextTrigger);
    }
    public void StartDialogue(int startLine, int endLine, GameObject nextTrigger)//неачать диалог
    {
        choiceNextTrigger = nextTrigger;
        panelAnim.SetBool("PanelShow", true);
        SetUI(false);
        for (int i = startLine; i < endLine; i++)
        {
            linesTriggered.Enqueue(file[i]);
        }
        DisplayNextLine();
    }
    public void DisplayNextLine()//показать следущую строку
    {
        if(!isDialogueTyping)
        {
            if (linesTriggered.Count == 0)
            {
                EndDialogue();
                return;
            }
            string line = linesTriggered.Dequeue();
            StopAllCoroutines();
            StartCoroutine(TypeLine(line));
        }
        else
        {
            typeDialogeInstantly = true;
        }
    }

    IEnumerator TypeLine(string sentence)//написать строку заменив иконки и имена
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
            isDialogueTyping = true;
            if(!typeDialogeInstantly)
            {
                yield return new WaitForSecondsRealtime(0.04f);
                output.text += letter;
            }
            else
            {
                output.text = sentence;
                break;
            }
               
        }
        isDialogueTyping = false;
        typeDialogeInstantly = false;
    }   
    public void EndDialogue()//закончить диалог 
    {
        if (choiceNextTrigger)
            choiceNextTrigger.SetActive(true);
        panelAnim.SetBool("PanelShow", false);
        SetUI(true);
    }
}