using UnityEngine;
using System;

public class ParallaxHandler : MonoBehaviour
{
    [SerializeField] ParallaxBackground[] backgrounds;
    Transform parallaxObject;

    Vector3 target;
    Vector3 parallax;

    public void Awake()
    {
        parallaxObject = Camera.main.transform;
        transform.position = new Vector3(parallaxObject.position.x, parallaxObject.position.y, transform.position.z);

        target = new Vector3(parallaxObject.position.x, parallaxObject.position.y);
        parallax = new Vector3(transform.position.x, transform.position.y);
    }

    private void Update()
    {
        if (parallaxObject)
            Move_Background();
    }

    void Move_Background()
    {
        target.x = parallaxObject.position.x;
        target.y = parallaxObject.position.y;
        parallax.x = transform.position.x;
        parallax.y = transform.position.y;

        if (target == parallax)
            return;
        Vector3 delta = target - parallax;
        foreach (ParallaxBackground background in backgrounds)
            background.background.position -= delta * background.speed;
        transform.position = new Vector3(parallaxObject.position.x, parallaxObject.position.y, transform.position.z);
    }
}

[Serializable]
public class ParallaxBackground
{
    public Transform background;
    public float speed;
}
