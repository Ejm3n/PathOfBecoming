using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class ButtonsMenuActions : MonoBehaviour
{
    [SerializeField] private GameObject[] button; // набор элементов из Canvas
    public UnityEvent FadeEvent; // событие затухания

    /// <summary>
    /// Переход на следующий уровень
    /// </summary>
    public void GoToGame()
    {
        FadeEvent.Invoke();
    }

    /// <summary>
    /// Действия при выборе меню "Выход из игры"
    /// </summary>
    public void TryQuit()
    {
        button[6].SetActive(true);
        button[7].SetActive(true);
    }

    /// <summary>
    /// Возврат в меню
    /// </summary>
    public void GoToMenu()
    {
        button[6].SetActive(false);
        button[7].SetActive(false);
    }

    /// <summary>
    /// Выход
    /// </summary>
    public void Quit()
    {
        Application.Quit();
    }
}
