using UnityEngine;

public class Interact : MonoBehaviour
{
    [SerializeField] HintMap hintMap;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        hintMap.Highlight();
    }
}
