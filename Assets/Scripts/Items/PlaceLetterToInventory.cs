using UnityEngine;

public class PlaceLetterToInventory : MonoBehaviour
{
    [SerializeField] Inventory inventory;
    [SerializeField] GameObject whatToSpawn;   
    [SerializeField] GameObject[] whatActivate;
    private void OnMouseUp()
    {
        for (int i = 0; i < inventory.slots.Length; i++)//просто спавним письмо в инвентаре
            if (inventory.isFull[i] == false)
            {
                inventory.isFull[i] = true;
                Instantiate(whatToSpawn, inventory.slots[i].transform);
                break;
            }
        for(int i = 0; i<whatActivate.Length;i++)
        {
            whatActivate[i].SetActive(true);
        }
        Destroy(gameObject);
    }
}

