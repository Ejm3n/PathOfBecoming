
public class StartNextLevel : InteractEvent
{
    public override void Start_Event()
    {
        onSuccess?.Invoke();
    }
}
