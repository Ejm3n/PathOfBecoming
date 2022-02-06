using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DoorPuzzle : Puzzle
{
    [SerializeField] Begunok begunok;
    float topPoint;
    [SerializeField] List<SpriteRenderer> leftImages;
    [SerializeField] List<SpriteRenderer> rightImages;
    [SerializeField] SpriteRenderer[] leftColumn;
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
            canPress = false;
        }

        if (begunok.GetCurrentHeight() == topPoint)
        {
            Debug.Log(begunok.NumberTimesWent);
            if(begunok.NumberTimesWent != 5-sprites.Count && !lastMove && begunok.AtTopPoint)
            {
                OnLose();
            }
            if (!FINISHED && !lastMove && sprites.Count != 2)
            {
                MixImages();
                canPress = true;
            }
            else if (!FINISHED && lastMove)
            {
                bool check = true;
                for (int i = 0; i < leftColumn.Length; i++)
                {
                    if (leftColumn[i].enabled)
                    {
                        check = false;
                        break;
                    }
                }
                if (check)
                {
                    Debug.Log("WIN PUZZLE");
                    FINISHED = true;
                    Solve_Puzzle();                   
                }
                //else
                //{
                //    OnLose();
                //}
            }
            if (sprites.Count == 2 && !lastMove)
            {
                EqualAllImages();
                lastMove = true;
            }
        }
       
        if (sprites.Count <= 2)
        {
            canPress = true;
        }
    }
    private void OnLose()
    {
        Debug.Log("lose");
        Fail_Puzzle();
    }
    private void EqualAllImages()
    {
        for (int i = 0; i < rightImages.Count; i++)
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
                if (i != correctNum)
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
            
        }
        else if (begunokPos < 6f && begunokPos > 2f)
        {
            whereClicked = 1;
            
        }
        else if (begunokPos < 2f && begunokPos > -2f)
        {
            whereClicked = 2;
            
        }
        else if (begunokPos < -2f && begunokPos > -6f)
        {
            whereClicked = 3;
           
        }
        else if (begunokPos < -6f && begunokPos > -10f)
        {
            whereClicked = 4;
            
        }
        else
        {
            whereClicked = -1;
            
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
                    OnLose();
                    
                }
            }
            else if (leftColumn[whereClicked].enabled && leftColumn[whereClicked].sprite == rightColumn[whereClicked].sprite)
            {
                leftColumn[whereClicked].enabled = false;
                rightColumn[whereClicked].enabled = false;
            }
            else
            {
                OnLose();
                
            }
        }



    }
    private void ColorCorrectBlocks()
    {
        leftImages[correctAnswer].enabled = false;
        rightImages[correctAnswer].enabled = false;
    }
}
