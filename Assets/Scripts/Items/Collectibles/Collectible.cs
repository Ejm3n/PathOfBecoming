using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Collectible : MonoBehaviour
{
    [SerializeField] GameObject inventoryItem;

    PlaceForItem attached;

    public void Attach(PlaceForItem place)
    {
        attached = place;
    }

    private void OnMouseDown()
    {
        if (Interface.current.inventory.Add_To_Inventory(inventoryItem))
        {
            if (attached)
                attached.On_Detach();
            Destroy(gameObject);
        }
    }
}
