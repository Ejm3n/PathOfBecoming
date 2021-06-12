using UnityEngine.SceneManagement;

public class WormholeInteract : InteractEvent
{
    public override void Start_Event()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
