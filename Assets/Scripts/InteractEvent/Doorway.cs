using UnityEngine;

public class Doorway : InteractEvent
{
    [SerializeField] Transform exit;
    public override void Start_Event()
    {
        onSuccess.AddListener(Travel);
        onSuccess?.Invoke();
    }

    private void Travel()
    {
        Engine.current.Hide_Scene(() =>
        {
            Engine.current.player.transform.position = exit.position;
            Engine.current.playerController.Change_Controls<UncontrollableHandler>();
            Engine.current.fairy.transform.position = exit.position;
            Engine.current.Show_Scene(() =>
            {
                Engine.current.playerController.Change_Controls<DefaultHandler>();
            });
        });
    }
}
