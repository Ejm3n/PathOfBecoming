using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlockPuzzleInterface : MonoBehaviour
{
    [SerializeField]Text Manatext;
    [SerializeField] Button but;
    [SerializeField] Text youWinText;
    BlockPuzzle bp;
    private void Awake()
    {
        bp = GetComponent<BlockPuzzle>();
    }
    private void Update()
    {
        Manatext.text = bp.CurrentMana.ToString();
        if (bp.GameEnded)
        {
            EndTexts("победа");
        }
        else if (bp.CurrentMana <= 0)
        {
            EndTexts("поражение");
        }
        else
        {
            youWinText.gameObject.SetActive(false);            
        }
    }
    private void EndTexts(string output)
    {
        youWinText.gameObject.SetActive(true);
        youWinText.text = output;       
    }
}
