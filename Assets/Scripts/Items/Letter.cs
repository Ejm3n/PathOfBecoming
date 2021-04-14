using UnityEngine;
public class Letter : MonoBehaviour
{
    private CanvasGroup letter;
    public void OnClick()//метод вешается на листик, на кнопку и включает листик из канваса
    {
        letter = GameObject.FindGameObjectWithTag("Letter").GetComponent<CanvasGroup>();//находим листик среди всех элементов
        letter.alpha = 1;
        letter.interactable = true;
        letter.blocksRaycasts = true;
    }
}
