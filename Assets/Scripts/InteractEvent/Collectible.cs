using UnityEngine;
using UnityEngine.Events;

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
        UnityEvent _event = new UnityEvent();
        _event.AddListener(Pick_Up);
        _event.AddListener(() => onSuccess?.Invoke());
        _event?.Invoke();
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
