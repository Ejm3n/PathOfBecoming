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
        Color _imageTransparent = _image.color;
        Color _textTransparent = _description.color;
        _imageTransparent.a = 0;
        _textTransparent.a = 0;
        _image.color = _imageTransparent;
        _description.color = _textTransparent;
    }

    IEnumerator Description_Window(float delay)
    {
        yield return new WaitForSeconds(delay);
        _image.Unfade(0.5f);
        _description.Unfade(0.5f);
    }
}
