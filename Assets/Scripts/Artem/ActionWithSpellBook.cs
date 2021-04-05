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
                    break;
                case "Spell (1)":
                    animator.SetBool("ShooseSpellTwo", true);
                    break;
                case "Spell (2)":
                    animator.SetBool("ShooseSpellThree", true);
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
}
