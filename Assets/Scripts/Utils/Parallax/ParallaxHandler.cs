using UnityEngine;
using System;

public class ParallaxHandler : MonoBehaviour
{
    [SerializeField] ParallaxBackground[] backgrounds;
    Transform parallaxObject;

    Vector3 target;
    Vector3 parallax;

    public void Start()
    {
        parallaxObject = Camera.main.transform;

        target = new Vector3(parallaxObject.position.x, parallaxObject.position.y);
        parallax = new Vector3(target.x, target.y);
    }

    private void Update()
    {
        if (parallaxObject)
            Move_Background();
    }

    void Move_Background()
    {
        target.x = parallaxObject.position.x;

        if (target == parallax)
            return;
        Vector3 delta = target - parallax;
        foreach (ParallaxBackground background in backgrounds)
            background.background.position -= delta * background.speed;
        parallax.x = target.x;
    }
}

[Serializable]
public class ParallaxBackground
{
    public Transform background;
    public float speed;
}
