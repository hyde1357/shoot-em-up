using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Title screen script
/// </summary>
public class MenuScript : MonoBehaviour
{
    public void StartGame()
    {
        // "Stage1" is the name of the first scene we created.
        SceneManager.LoadScene(1);
    }

    public void OpenCredits()
    {
        SceneManager.LoadScene(2);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}