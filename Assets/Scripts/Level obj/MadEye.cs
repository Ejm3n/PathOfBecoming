using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AnimationUtils.RenderUtils;
using AnimationUtils.TransformUtils;

public class MadEye : MonoBehaviour
{
    private SpriteRenderer _renderer;

    private void Awake()
    {
        _renderer = GetComponent<SpriteRenderer>();
        _renderer.Unfade(0.1f, Random_Movement);
    }

    private void Random_Movement()
    {
        Vector3 direction = new Vector3(Random.Range(0.5f, 1f), Random.Range(-1f, 1f), 0);
        transform.Move_To(transform.position + direction, 3f, () => {
            _renderer.Fade(0.1f, () => Destroy(gameObject));
        }
        );
    }
}
