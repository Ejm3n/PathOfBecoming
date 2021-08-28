using UnityEngine;
using UnityEngine.UI;

public class Interface : MonoBehaviour
{
    [SerializeField] protected Engine engine;
    public Image curtain;
    public Transform canvas;
    public Inventory inventory;
    public Spellbook spellBook;
    public ManaCounter mana;
    public Image healthBar;

    public static Interface current;

    private void Awake()
    {
        current = this;
    }

    public void Spawn_UI_Object(GameObject prefab)
    {
        Instantiate(prefab, canvas);
    }
}
