using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Collectible : InteractEvent
{
    [SerializeField] GameObject inventoryItem;

    PlaceForItem attached;
    AudioClip _pickUp;

    private void Awake()
    {
        _pickUp = Resources.Load<AudioClip>("Sounds/Effects/pickup");
    }

    public void Attach(PlaceForItem place)
    {
        attached = place;
    }

    public override void Start_Event()
    {
        onSuccess.AddListener(Pick_Up);
        onSuccess.Invoke();
    }

    private void OnMouseDown()
    {
        Pick_Up();
    }

    private void Pick_Up()
    {
        if (Interface.current.inventory.Add_To_Inventory(inventoryItem))
        {
            SoundRecorder.Play_Effect(_pickUp);
            if (attached)
                attached.On_Detach();
            Destroy(gameObject);
        }
    }
}
