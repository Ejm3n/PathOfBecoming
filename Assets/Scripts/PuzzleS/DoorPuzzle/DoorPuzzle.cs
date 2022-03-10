using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[System.Serializable]
public class DoorPuzzleLine
{
    public SpriteRenderer leftSr;
    public SpriteRenderer rightSr;
    public bool IsActive = true;
    public void DisableLine()
    {
        leftSr.enabled = false;
        rightSr.enabled = false;
        IsActive = false;
    }
    public void EnableLine()
    {
        leftSr.enabled = true;
        rightSr.enabled = true;
        IsActive = true;
    }

}


public class DoorPuzzle : Puzzle
{
    [SerializeField] Begunok begunok;
    float topPoint;

    [SerializeField] private DoorPuzzleLine[] lines;
    [SerializeField] List<Sprite> sprites;
    
    int correctAnswer;
    bool canPress = true;
    public bool FINISHED = false;
    private bool lastMove = false;
    private void Start()
    {
        topPoint = begunok.GetMaxHeight();
        foreach (DoorPuzzleLine dpl in lines)
            dpl.IsActive = true;
        RandomizeBegunokImage();
        
    }


    private void Update()
    {
        int answered = 0;
        if (Input.GetKeyDown(KeyCode.Space) && canPress && !FINISHED)
        {
            Clicked();
            canPress = false;
        }
        foreach(DoorPuzzleLine dpl in lines)
        {
            if (dpl.IsActive)
                answered++;
        }
        if(answered==0)
            Solve_Puzzle();

        if (begunok.GetCurrentHeight() == topPoint)
        {
            Debug.Log(begunok.NumberTimesWent);
            if(begunok.NumberTimesWent != 5-answered && !lastMove && begunok.AtTopPoint)
            {
                OnLose();
            }
            
                RandomizeBegunokImage();
                canPress = true;
            
            //else if (!FINISHED && lastMove)
            //{
            //    bool check = true;
            //    for (int i = 0; i < lines.Length; i++)
            //    {
            //        if (lines[i].IsActive)
            //        {
            //            check = false;
            //            break;
            //        }
            //    }
            //    if (check)
            //    {
            //        FINISHED = true;
            //        Solve_Puzzle();                   
            //    }
            //    //else
            //    //{
            //    //    OnLose();
            //    //}
            //}
            //if (sprites.Count == 2 && !lastMove)
            //{
                
            //    lastMove = true;
            //}
        }
       
        //if (sprites.Count <= 2)
        //{
        //    canPress = true;
        //}
    }
    private void OnLose()
    {
        Debug.Log("lose");
        Fail_Puzzle();
    }
    
    private void RandomizeBegunokImage()
    {
        while(true)
        {
            correctAnswer = Random.Range(0, 5);
            if (lines[correctAnswer].IsActive)
            {
                begunok.spriteRenderer.sprite = sprites[correctAnswer];
                break;
            }
               
        }
    }
    private void Clicked()
    {
        int whereClicked;
        float begunokPos = begunok.GetCurrentHeight();

        if (begunokPos < 3.5f && begunokPos > 2.5f)
        {
            whereClicked = 0;
            
        }
        else if (begunokPos < 2f && begunokPos > 1f)
        {
            whereClicked = 1;
            
        }
        else if (begunokPos < 0.5f && begunokPos > -0.5f)
        {
            whereClicked = 2;
            
        }
        else if (begunokPos < -1f && begunokPos > -2f)
        {
            whereClicked = 3;
           
        }
        else if (begunokPos < -2.5f && begunokPos > -3.5f)
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
                if (lines[whereClicked].IsActive && whereClicked == correctAnswer)
                {
                    //ColorCorrectBlocks();
                    lines[whereClicked].DisableLine();
                    //sprites.RemoveAt(correctAnswer);
                }
                else
                {
                    OnLose();
                    
                }
            }
            else if (lines[whereClicked].IsActive && whereClicked == correctAnswer)
            {
                lines[whereClicked].DisableLine();
            }
            else
            {
                OnLose();
                
            }
        }



    }
    private void ColorCorrectBlocks()
    {
        //lines[correctAnswer].HideLine();
    }
}
