using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [SerializeField] private string SceneOne;
    [SerializeField] private string Credits;

    public void StartGame()
    {
        SceneManager.LoadScene(SceneOne);
    }

    public void GoToCredits()
    {
        SceneManager.LoadScene(Credits);
    }

    public void ExitGame()
    {
        Application.Quit();
    }



}
