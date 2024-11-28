using UnityEngine;
using UnityEngine.SceneManagement;
public class HotKeys : MonoBehaviour
{
    private bool paused = false;
    public GameObject panel;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!paused)
            {
                Time.timeScale = 0;
                paused = true;
                panel.SetActive(true);
            }
            else
            {
                Time.timeScale = 1;
                paused = false;
                panel.SetActive(false);
            }
        }
        if (Input.GetKeyDown(KeyCode.Return))
        {
            Debug.Log("Play Game");
            SceneManager.LoadScene("Scenes/MainScene");
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Debug.Log("Quit Game");
            Application.Quit();
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Show Menu");
            SceneManager.LoadScene("Scenes/MenuScene");
        }
    }
}