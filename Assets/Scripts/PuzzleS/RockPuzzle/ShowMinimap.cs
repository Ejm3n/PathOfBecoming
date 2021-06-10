using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowMinimap : MonoBehaviour
{
    [SerializeField] GameObject minimap;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            minimap.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            minimap.SetActive(false);
        }
    }
}
