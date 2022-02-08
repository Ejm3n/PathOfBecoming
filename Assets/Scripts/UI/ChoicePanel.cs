using UnityEngine;
using UnityEngine.UI;
using AnimationUtils.TransformUtils;
public class ChoicePanel : MonoBehaviour
{
    public GameObject[] chooseButtons;
    public Transform indicator;
    
    public void RewriteButtons(ChoiceDialogueTrigger cdt)
    {

        for (int i = 0; i<cdt.choices.Count;i++)
        {
            chooseButtons[i].SetActive(true);
            chooseButtons[i].transform.GetChild(0).GetComponent<Text>().text = cdt.choices[i].phrase;
        }

        MoveIndicator(0);//ПЕРЕДЕЛАТЬ ТАМ БАГ ПОСЛЕ ПЕРВОГО ВЫБОРА
    }
    public void DisablePanel()
    {
        foreach(GameObject button in chooseButtons)
        {
            button.SetActive(false);
        }
    }
    public void MoveIndicator(int index)
    {
        indicator.transform.position = new Vector2(indicator.position.x, chooseButtons[index].transform.position.y);
        //indicator.Move_To(new Vector2(indicator.position.x,chooseButtons[index].transform.position.y), 0.1f, false);
    }
}
