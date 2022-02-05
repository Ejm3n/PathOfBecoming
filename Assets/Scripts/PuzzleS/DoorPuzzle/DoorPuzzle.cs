using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DoorPuzzle : Puzzle
{
    [SerializeField] Begunok begunok;
    float topPoint;
    [SerializeField] List<SpriteRenderer> leftImages;
    [SerializeField] List<SpriteRenderer> rightImages;
    [SerializeField]SpriteRenderer[] leftColumn;
   [SerializeField] SpriteRenderer[] rightColumn;

    [SerializeField] List<Sprite> sprites;
    int correctAnswer;
    bool canPress = true;
    public bool FINISHED = false;
    private bool lastMove = false;
    private void Start()
    {
        topPoint = begunok.GetMaxHeight();
        MixImages();
        leftColumn = leftImages.ToArray();
        rightColumn = rightImages.ToArray();
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && canPress && !FINISHED)
        {
            Clicked();
            canPress = true;
        }
        if (sprites.Count == 2)
        {
            EqualAllImages();
            lastMove = true;
        }
        if (begunok.GetCurrentHeight() == topPoint )
        {
            if( !FINISHED && !lastMove)
            {
                MixImages();
                canPress = true;
            }
           else if(!FINISHED && lastMove)
            {
                bool check = true;
                for(int i = 0; i<leftColumn.Length;i++)
                {
                    if(leftColumn[i].enabled)
                    {
                        check = false;
                        break;
                    }
                }
                if(check)
                {
                    FINISHED = true;
                    Solve_Puzzle();
                    Debug.Log("WIN!!!!!!!!!!!");
                }
                else
                {
                    OnLose();
                }
            }
        }
    }
    private void OnLose()
    {
        Fail_Puzzle();
    }
    private void EqualAllImages()
    {
        for(int i =0;i<rightImages.Count;i++)
        {
            rightImages[i].sprite = leftImages[i].sprite;
        }      
    }
    private void MixImages()
    {
        //смотри млевую сторону 
        int maxNum = sprites.Count;
        List<Sprite> randomList = sprites.OrderBy(x => Random.Range(0, maxNum)).ToList();
        sprites = randomList;
        for (int i = 0; i < leftImages.Count; i++)
        {
            leftImages[i].sprite = sprites[i];
            rightImages[i].sprite = sprites[i];
        }
        //смотрим правую сторону         
        int correctNum = Random.Range(0, maxNum);// позиция правильного ответа
        correctAnswer = correctNum;
        List<int> positions = new List<int>();
        for (int i = 0; i < maxNum; i++)
        {
            if (i != correctNum)
                positions.Add(i);
        }
        bool correct = true;

        do
        {
            correct = true;
            randomList = sprites.FindAll(e => e != leftImages[correctNum].sprite).OrderBy(x => Random.Range(0, maxNum)).ToList();
            randomList.Add(sprites[correctNum]);
            if (randomList.Count - 1 != correctNum)
            {
                Sprite temp = randomList[correctNum];
                randomList[correctNum] = randomList[randomList.Count - 1];
                randomList[randomList.Count - 1] = temp;
            }
            for (int i = 0; i < maxNum; i++)
            {
                rightImages[i].sprite = randomList[i];
                if(i!=correctNum)
                {
                    if (rightImages[i].sprite == leftImages[i].sprite)
                    {
                        correct = false;
                        break;
                    }

                }
            }
        } while (!correct);      
    }
    private void Clicked()
    {
        int whereClicked;
        float begunokPos = begunok.GetCurrentHeight();

        if (begunokPos < 10f && begunokPos > 6f)
        {
            whereClicked = 0;
            Debug.Log("нажат 0 куб");
        }
        else if (begunokPos < 6f && begunokPos > 2f)
        {
            whereClicked = 1;
            Debug.Log("нажат 1 куб");
        }
        else if (begunokPos < 2f && begunokPos > -2f)
        {
            whereClicked = 2;
            Debug.Log("нажат 2 куб");
        }
        else if (begunokPos < -2f && begunokPos > -6f)
        {
            whereClicked = 3;
            Debug.Log("нажат 3 куб");
        }
        else if (begunokPos < -6f && begunokPos > -10f)
        {
            whereClicked = 4;
            Debug.Log("нажат 4 куб");
        }
        else
        {
            whereClicked = -1;
            Debug.LogError("БЕГУНОК НАЖАТ ЗА ГРАНИЦАМИ");
        }
        if (whereClicked != -1)
        {
            if (!lastMove)
            {
                if (leftColumn[whereClicked].enabled && leftColumn[whereClicked].sprite == rightColumn[whereClicked].sprite)
                {
                    ColorCorrectBlocks();
                    leftImages.RemoveAt(correctAnswer);
                    rightImages.RemoveAt(correctAnswer);
                    sprites.RemoveAt(correctAnswer);
                }
                else
                    {
                    Debug.Log("ПОРАЖЕНИЕ");
                }
            }
            else if (leftColumn[whereClicked].enabled && leftColumn[whereClicked].sprite == rightColumn[whereClicked].sprite)
            {
                leftColumn[whereClicked].enabled = false;
                rightColumn[whereClicked].enabled = false;
            }
            else
            {
                Debug.Log("ПОРАЖЕНИЕ 2");
            }
        }

        
       
    }
    private void ColorCorrectBlocks()
    {
        leftImages[correctAnswer].enabled = false;
        rightImages[correctAnswer].enabled = false;
    }
}
