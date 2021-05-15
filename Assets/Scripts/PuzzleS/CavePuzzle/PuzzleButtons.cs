using UnityEngine;
using UnityEngine.UI;
public class PuzzleButtons : MonoBehaviour
{
    private Color colorIfPressed = new Color(255f, 120f, 0f, 0.20f);
     public Image Sprite;
    [SerializeField] CavePuzzle CavePzz;
    [SerializeField] int ButtonNum;
    private void Start()
    {
        Sprite = GetComponent<Image>();
    }
    public void OnStoneClicked()
    {
        Debug.Log("нажата кнопка в головоломке");
        Sprite.color = colorIfPressed;
        CavePzz.OnPuzzleButtonClick(ButtonNum);
    }
}
