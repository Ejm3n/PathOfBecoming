using UnityEngine;

public class CageOpen : MonoBehaviour
{
    [SerializeField] private SpriteRenderer cage;
    [SerializeField] private SpriteRenderer door;
    [SerializeField] private SpriteRenderer cageBack;

    private Animator anim;
    void Awake()
    {
        anim = GetComponent<Animator>();
    }
    public void Open_Cage()
    {
        cageBack.sortingOrder = 0;
        cage.sortingOrder = 1;
        door.sortingOrder = 2;
        anim.SetBool("open", true);
    }
}
