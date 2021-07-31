using UnityEngine;

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
        if (!Input.GetMouseButtonDown(0) || UICheck.overUI)
            return;
        Player_Direction();
        Interface.current.spellBook.Cast_Chosen_Spell(firePoint);
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
