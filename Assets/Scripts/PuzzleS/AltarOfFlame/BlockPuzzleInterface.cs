using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlockPuzzleInterface : MonoBehaviour
{
    [SerializeField]Text Manatext;
    [SerializeField] Image manaImage;
    [SerializeField] Button but;
    [SerializeField] Text youWinText;
    BlockPuzzle bp;
    private void Awake()
    {
        bp = GetComponent<BlockPuzzle>();
    }
    private void Update()
    {
        manaImage.fillAmount = (float) bp.CurrentMana / 100f;
        //Debug.Log((float) bp.CurrentMana / 100);
        Manatext.text = bp.CurrentMana.ToString();
        if (bp.GameEnded)
        {
            EndTexts("победа");
        }
        else if (bp.CurrentMana <= 0)
        {
            EndTexts("поражение");
            Destroy(gameObject);
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
