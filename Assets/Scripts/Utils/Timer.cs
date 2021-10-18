using AnimationUtils.RenderUtils;
using System;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] float seconds;
    [SerializeField] Color colorFrom;
    [SerializeField] Color colorTo;

    SpriteRenderer colorMeter;
    Color hideColor = new Color(0, 0, 0, 0);

    float startTime;

    float red;
    float green;
    float blue;

    bool tick_tock = false;

    Vector3 scale;

    Action onEnd;

    void Awake()
    {
        colorMeter = transform.GetChild(0).GetComponent<SpriteRenderer>();
        scale = transform.localScale;
    }

    public void Start_Timer(Action onEnd)
    {
        this.onEnd = onEnd;
        startTime = Time.time;
        Set_Color_Step();
        tick_tock = true;
        colorMeter.color = colorFrom;
    }

    public void Continue_Timer()
    {
        tick_tock = true;
    }

    public void Pause_Timer()
    {
        tick_tock = false;
    }

    public void Stop_Timer()
    {
        tick_tock = false;
        colorMeter.color = hideColor;
    }

    public void Add_Time(float seconds)
    {
        Change_Time(seconds);
    }

    public void Remove_Time(float seconds)
    {
        Change_Time(-seconds);
    }

    void Update()
    {
        Tick_Tock();
    }

    void Tick_Tock()
    {
        if (!tick_tock)
            return;

        float timePassed = Time.time - startTime;

        scale.y = Mathf.Clamp(1 - (timePassed / seconds), 0, 1);
        transform.localScale = scale;

        colorMeter.color = new Color(colorFrom.r + red * timePassed, colorFrom.g + green * timePassed, colorFrom.b + blue * timePassed);

        Check_Timer();
    }

    void Check_Timer()
    {
        if (transform.localScale.y != 0)
            return;
        onEnd.Invoke();
        Stop_Timer();
    }

    void Set_Color_Step()
    {
        red = (colorTo.r - colorFrom.r) / seconds;
        green = (colorTo.g - colorFrom.g) / seconds;
        blue = (colorTo.b - colorFrom.b) / seconds;
    }

    void Change_Time(float seconds)
    {
        this.seconds += seconds;
        Set_Color_Step();
    }
}
