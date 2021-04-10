using UnityEngine;

public class PlaceLetterToInventory : MonoBehaviour
{
    [SerializeField] Inventory inventory;
    [SerializeField] GameObject whatToSpawn;
    int choosenSlot = -1;
    [SerializeField] GameObject[] whatActivate;
    private void OnMouseDown()
    {

        for (int i = 0; i < inventory.isChosen.Length; i++)
        {
            if (inventory.isChosen[i])
            {
                choosenSlot = i;
                break;
            }
        }
        for (int i = 0; i < inventory.slots.Length; i++)
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

