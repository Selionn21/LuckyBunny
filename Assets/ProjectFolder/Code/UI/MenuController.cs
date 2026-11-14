using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{

    public void StartGame()
    {
        SceneManager.LoadScene("Level 1");
    }

    public void GoToCredits()
    {
        SceneManager.LoadScene("Credits");
    }

    public void ExitGame()
    {
        Application.Quit();
    }



}
