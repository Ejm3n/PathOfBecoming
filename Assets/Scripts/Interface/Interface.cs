using UnityEngine;

public class Interface : MonoBehaviour
{
    [SerializeField] Transform canvas;
    public Inventory inventory;
    //[SerializeField] spellbook
    public static Interface current;

    private void Start()
    {
        current = this;
    }

    public void Spawn_UI_Object(GameObject prefab)
    {
        Instantiate(prefab, canvas);
    }
}
