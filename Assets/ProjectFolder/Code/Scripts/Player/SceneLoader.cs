using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [Header("Ponle el canva Group a tu pantalla con victoria")]
    [SerializeField] private float fadeSpeed = 2f;

    public void ShowPanel(CanvasGroup panel)
    {
        panel.gameObject.SetActive(true);
        panel.alpha = 0f;
        panel.interactable = true;
        panel.blocksRaycasts = true;
        StartCoroutine(FadeIn(panel));
    }
    private IEnumerator FadeIn(CanvasGroup panel)
    {
        while (panel.alpha < 1f)
        {
            panel.alpha += Time.unscaledDeltaTime * fadeSpeed;
            yield return null;
        }
        panel.alpha = 1f;
    }
    public void LoadNextLevel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void LoadLevelByName(string levelName)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(levelName);
    }

    public void ReloadLevel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
