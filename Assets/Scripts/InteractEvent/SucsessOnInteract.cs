
public class SucsessOnInteract : InteractEvent
{
    public override void Start_Event()
    {
        onSuccess?.Invoke();
    }
}
