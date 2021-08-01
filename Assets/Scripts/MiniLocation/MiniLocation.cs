using UnityEngine;
using Cinemachine;
using UnityEngine.Events;

public class MiniLocation : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera locationCamera;
    [SerializeField] UnityEvent onEnter;
    [SerializeField] UnityEvent onExit;

    protected Engine engine;

    public void Enter_Location()
    {
        engine = Engine.current;
        engine.dialogueSystem.SetUI(false);
        engine.Hide_Scene(On_Enter);
    }

    public void Exit_Location()
    {
        engine.dialogueSystem.SetUI(false);
        engine.Hide_Scene(On_Exit);
    }

    protected virtual void On_Enter()
    {
        locationCamera.Priority = 11;
        engine.Show_Scene(() => onEnter?.Invoke());
    }

    protected virtual void On_Exit()
    {
        locationCamera.Priority = 1;
        engine.Show_Scene(() => onExit?.Invoke());
        Destroy(gameObject);
    }
}
