using UnityEngine;

public class CageOpen : MonoBehaviour
{
    [SerializeField] private SpriteRenderer cage;
    private SpriteRenderer door;

    private Animator anim;
    void Awake()
    {
        anim = GetComponent<Animator>();
        door = GetComponent<SpriteRenderer>();
    }
    public void Open_Cage()
    {
        cage.sortingLayerName = "Middle";
        door.sortingLayerName = "Middle";
        anim.SetBool("open", true);
    }
}
