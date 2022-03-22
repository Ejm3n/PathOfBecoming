using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResolutionController : MonoBehaviour
{
    [SerializeField] Dropdown resolutionDropdown;
    public void Change()
    {
        int[] widthHeight = GetResolutions(resolutionDropdown.value);
        Screen.SetResolution(widthHeight[0],widthHeight[1], true);
    }
    public void FullScreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }
    public void ChangeBrightness(float level)
    {
        Screen.brightness = level;
    }
    private int[] GetResolutions(int option)
    {
        string res = resolutionDropdown.options[option].text;
        int[] widthNheight = new int[2];
        int position = res.IndexOf("x");
        widthNheight[0] = int.Parse(res.Substring(0, position));
        widthNheight[1] = int.Parse(res.Substring(position +1));
        return widthNheight;
    }

}
