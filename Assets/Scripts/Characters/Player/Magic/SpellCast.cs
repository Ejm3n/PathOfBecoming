using UnityEngine;
using Settings;

public class SpellCast : MonoBehaviour
{
    [SerializeField] Transform firePoint;
    PlayerController playerController;

    private void Awake()
    {
        playerController = GetComponent<PlayerController>();
    }

    private void Update()
    {
        if (!ControlButtons.USESPELL)
            return;
        //Player_Direction();
        Interface.current.spellBook.Cast_Chosen_Spell(firePoint.position);
    }

    private void Player_Direction()
    {
        float dir = Camera.main.ScreenToWorldPoint(Input.mousePosition).x - firePoint.position.x;
        if (dir < 0 && playerController.faceRight)
            playerController.Flip();
        else if (dir >= 0 && !playerController.faceRight)
            playerController.Flip();
    }
}
