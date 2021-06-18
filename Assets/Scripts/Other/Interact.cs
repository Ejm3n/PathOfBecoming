using UnityEngine;

public class Interact : MonoBehaviour
{
    HintMap hintMap;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        hintMap = collision.GetComponent<HintMap>();
        hintMap.Highlight();
    }
}
