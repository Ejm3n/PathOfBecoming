using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using AnimationUtils.ImageUtils;
using AnimationUtils.TextUtils;

public class ItemDescription : MonoBehaviour
{
    [SerializeField] Text _description;
    Image _image;
    Coroutine _window;

    private void Start()
    {
        _image = GetComponent<Image>();
        Hide_Description();
    }

    public void Set_Description(string description)
    {
        Hide_Description();
        _description.text = description;
        _window = StartCoroutine(Description_Window(2f));
    }

    public void Hide_Description()
    {
        if (_window != null)
            StopCoroutine(_window);
        _image.Fade(0);
        _description.Fade(0);
    }

    IEnumerator Description_Window(float delay)
    {
        yield return new WaitForSeconds(delay);
        _image.Unfade(0.5f);
        _description.Unfade(0.5f);
    }
}
