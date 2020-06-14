using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScreen : MonoBehaviour
{
    public GameObject Screen;
    private TopBar timer;

    public GameObject Bar;

    void Start()
    {
        timer = Bar.GetComponent<TopBar>();
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
