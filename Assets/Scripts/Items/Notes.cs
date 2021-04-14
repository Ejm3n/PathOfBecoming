using UnityEngine;
public class Notes : MonoBehaviour
{
    private CanvasGroup notes;
    private void OnEnable()
    {
        notes = GameObject.FindGameObjectWithTag("Notes").GetComponent<CanvasGroup>();//находим листик среди всех элементов
    }
    public void OnClick()//метод вешается на листик, на кнопку и включает листик из канваса
    {
        notes.alpha = 1;
        notes.interactable = true;
        notes.blocksRaycasts = true;
    }
}
