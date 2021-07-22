using UnityEngine.SceneManagement;

public class StartNextLevel : InteractEvent
{
    Engine engine;

    private void Awake()
    {
        engine = interactController.transform.parent.parent.GetComponent<Engine>();
    }

    public override void Start_Event()
    {
        Engine.load = false;
        onSuccess.AddListener(() =>
        {
            engine.Hide_Scene(() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1));
        });
        onSuccess?.Invoke();
    }
}
