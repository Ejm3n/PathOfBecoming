using UnityEngine;
using System.Collections;

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
        Engine.current.Hide_Scene(() => StartCoroutine(Unfade()));
    }

    IEnumerator Unfade()
    {
        Engine.current.player.transform.position = exit.position;
        Engine.current.playerController.Change_Controls<UncontrollableHandler>();
        Engine.current.fairy.transform.position = exit.position;
        yield return new WaitForSeconds(0.5f);
        Engine.current.Show_Scene();
    }
}
