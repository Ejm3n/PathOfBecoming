using UnityEngine;

public class CavePuzzle : MonoBehaviour
{
    bool[] isPressed = new bool[5] { false, false, false, false, false };
    int[] whatShouldBePressed = new int[5] { 8, 0, 11, 6, 12 };
    int currnum = 0;
    public bool GameWin;
    bool canUWin = true;
    [SerializeField] PuzzleButtons[] puzzleButtons;
    private Color colorIfUnpressed = new Color(255f, 155f, 0f, 0f);
    [SerializeField] GameObject nextDialogue;
    [SerializeField] DialogueSystem ds;
    private void Update()
    {
        if (isPressed[0] && isPressed[1] && isPressed[2] && isPressed[3] && isPressed[4]&& canUWin)
        {
            GameWin = true;
            Debug.Log("игра выиграна");
            if (nextDialogue != null)
            {
                nextDialogue.SetActive(true);
            }
          
            Destroy(gameObject);
            
        }   
    }
    public void OnPuzzleButtonClick(int num)
    {
        if (whatShouldBePressed[currnum] == num)
        {
            isPressed[currnum] = true;
            if(currnum<4)
            {
                currnum++;
            } 
        }
        else
        {
            canUWin = false;
        }
    }
    public void ClosePuzzle()
    {
        ds.SetUI(true);
        for(int i = 0;i<5;i++)
        {
            isPressed[i] = false;
        }
        canUWin = true;
        currnum = 0;
        for(int i = 0;i<16;i++)
        {
            puzzleButtons[i].Sprite.color = colorIfUnpressed;
        }
        gameObject.SetActive(false);
    }
}
