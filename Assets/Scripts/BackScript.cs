using UnityEngine;
using UnityEngine.SceneManagement;

public class BackScript : MonoBehaviour
{
    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }

}
