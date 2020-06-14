using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScreen : MonoBehaviour
{
    public GameObject Screen;
    private TopBar timer;

    // Start is called before the first frame update
    void Start()
    {
        Screen.SetActive(false);
    }

    public void onDeath()
    {
        Screen.SetActive(true);
        timer.stopTime();
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
