using System;
using UnityEngine;
using UnityEngine.UI;

public class InteractButton : MonoBehaviour
{
    Image buttonImage;
    Action action;

    private void Awake()
    {
        buttonImage = GetComponent<Image>();
    }
    public void Set_Button(Sprite buttonSprite, Action action)
    {
        buttonImage.sprite = buttonSprite;
        this.action = action;
    }
    public void Interact()
    {
        action();
        gameObject.SetActive(false);
    }
}
