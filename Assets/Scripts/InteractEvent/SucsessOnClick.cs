
public class SucsessOnClick : InteractEvent
{
    public override void Start_Event()
    {
        onSuccess?.Invoke();
    }
}
