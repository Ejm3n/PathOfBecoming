using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionWithSpellBook : MonoBehaviour
{
    [SerializeField] private Animator animator;

    [SerializeField] private Sprite openBook;
    [SerializeField] private Sprite closedBook;

    [SerializeField] private Button book;
    [SerializeField] private Image image;

    private bool isBookOpen = false;
    private bool isUseSpell = false;

    public bool[] Spells = new bool[3] { false,false,false};//добавил яша для отслеживания в других скриптах

    /// <summary>
    /// Открытие и закрытие книги
    /// </summary>
    public void OpenBook()
    {
        if (isBookOpen == true && isUseSpell == false) // если книга открыта
        {
            book.image.sprite = closedBook;
            isBookOpen = !isBookOpen;
            animator.SetBool("ShowSlots", isBookOpen);
        }
        else // если книга закрыта
        {
            book.image.sprite = openBook;
            isBookOpen = true;
            animator.SetBool("ShowSlots", isBookOpen);
        }
    }

    /// <summary>
    /// Механика панели с заклинаниями
    /// </summary>
    /// <param name="button"> выбранное заклинание </param>
    public void UseSpell(Button button)
    {
        if (isUseSpell == false)
        {
            isUseSpell = true;
            switch (button.name)
            {
                case "Spell":
                    animator.SetBool("ShooseSpellOne", true);
                   StartCoroutine( ChoosenSpell(0));
                    break;
                case "Spell (1)":
                    animator.SetBool("ShooseSpellTwo", true);
                    StartCoroutine(ChoosenSpell(1));
                    break;
                case "Spell (2)":
                    animator.SetBool("ShooseSpellThree", true);
                    StartCoroutine(ChoosenSpell(2));
                    break;
                default:
                    break;
            }
        }
        else
        {
            isUseSpell = !isUseSpell;
            animator.SetBool("ShooseSpellOne", isUseSpell);
            animator.SetBool("ShooseSpellTwo", isUseSpell);
            animator.SetBool("ShooseSpellThree", isUseSpell);
        }
    }
    //ниже метод писал Яша, надо отследить какой спел выбран  
    private IEnumerator ChoosenSpell(int num)
    {
       
        for(int i = 0; i<3;i++)
        {
            if(i==num)
            {
                yield return new WaitForSeconds(1);
                Spells[i] = true;
            }
            else
            {
                Spells[i] = false;
            }
        }
    }
}
