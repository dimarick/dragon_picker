using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        Debug.Log("Play Game");
        SceneManager.LoadScene("Scenes/MainScene");
    }

    public void ShowMenu()
    {
        Debug.Log("Show Menu");
        SceneManager.LoadScene("Scenes/MenuScene");
    }

    public void QuitGame()
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }
}