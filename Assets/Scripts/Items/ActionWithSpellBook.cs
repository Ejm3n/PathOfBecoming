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
 // private Image image;

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
            ChoosenSpell(4);
        }
        else // если книга закрыта
        {
            book.image.sprite = openBook; 
            isBookOpen = true;
            animator.SetBool("ShowSlots", isBookOpen);
            ChoosenSpell(4);
        }
    }

    /// <summary>
    /// Механика панели с заклинаниями
    /// </summary>
    /// <param name="button"> выбранное заклинание </param>
    public void UseSpell(Button button)
    {
        UseSpell(button.name);
    }

    public void UseSpell(string buttonName = null)
    {
        if (isUseSpell == false && buttonName != null)
        {
            isUseSpell = true;
            switch (buttonName)
            {
                case "Spell":
                    animator.SetBool("ShooseSpellOne", true);
                    ChoosenSpell(0);
                    break;
                case "Spell (1)":
                    animator.SetBool("ShooseSpellTwo", true);
                    ChoosenSpell(1);
                    break;
                case "Spell (2)":
                    animator.SetBool("ShooseSpellThree", true);
                    ChoosenSpell(2);
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
            for ( int i = 0; i < Spells.Length;i++ )
                Spells[i] = false;
        }
    }
    //ниже метод писал Яша, надо отследить какой спел выбран  
    private void ChoosenSpell(int num)
    {
       
        for(int i = 0; i<3;i++)
        {
            if(i==num)
            {
                Spells[i] = true;                
            }
            else
            {               
                Spells[i] = false;            
            }
        }
    }
}
