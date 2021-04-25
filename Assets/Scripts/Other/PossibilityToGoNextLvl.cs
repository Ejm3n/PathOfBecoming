using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PossibilityToGoNextLvl : MonoBehaviour
{
    ///
    /// проверка места где стоит игрок давать ли возможность перейти на след уровень
    ///
    [SerializeField] TransitionBetweenScenes TBS;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
            TBS.CanULoadNextLvl = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
            TBS.CanULoadNextLvl = false;
    }
}
