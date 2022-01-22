
using UnityEngine;
using UnityEngine.UI;

public class EyeOfHassle : Item
{
    [SerializeField] private Sprite awaken;
    [SerializeField] private Sprite asleep;

    public bool eyeAwaken {get; private set;}

    Image eyeImage;

    private void Start()
    {
        eyeImage = GetComponent<Image>();
        Eye_Asleep();
    }

    public override void Use()
    {
        return;
    }

    public void Eye_Awaken()
    {
        eyeImage.sprite = awaken;
        eyeAwaken = true;
    }

    public void Eye_Asleep()
    {
        eyeImage.sprite = asleep;
        eyeAwaken = false;
    }

}
