using UnityEngine;
using UnityEngine.SceneManagement;
public class LoadScenes : MonoBehaviour
{
    bool testMode = false;

    public void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void LoadGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("Game");
    }
}
