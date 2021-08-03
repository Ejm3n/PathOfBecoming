using UnityEngine;
using Cinemachine;
using UnityEngine.Events;

public class MiniLocation : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera locationCamera;
    [SerializeField] Transform locationEntrance;
    [SerializeField] Transform locationExit;
    [SerializeField] UnityEvent onEnter;
    [SerializeField] UnityEvent onExit;

    protected Engine engine;

    public void Enter_Location()
    {
        engine = Engine.current;
        engine.dialogueSystem.SetUI(false);
        if (locationEntrance)
            onEnter.AddListener(() => Move_Player(locationEntrance));
        engine.Hide_Scene(On_Enter);
    }

    public void Exit_Location()
    {
        engine.dialogueSystem.SetUI(false);
        engine.Hide_Scene(On_Exit);
    }

    protected void On_Enter()
    {
        locationCamera.Priority = 11;
        engine.Show_Scene(() => onEnter?.Invoke());
    }

    protected void On_Exit()
    {
        locationCamera.Priority = 1;
        if (locationExit)
            Move_Player(locationExit);
        engine.Show_Scene(Invoke_Exit);
    }

    void Invoke_Exit()
    {
        onExit?.Invoke();
    }

    public void Move_Player(Transform place)
    {
        engine.player.transform.position = place.position;
    }
}
