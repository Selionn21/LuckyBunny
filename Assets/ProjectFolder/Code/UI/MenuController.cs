using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    [SerializeField] private string SceneOne;

    [SerializeField] private bool inTransition = false;
    [SerializeField] private bool showingCredits = false;
    [SerializeField] private CanvasGroup menuArt;
    [SerializeField] private CanvasGroup credits;
    [SerializeField] private Button creditsButton;
    private Image buttonImage;
    [SerializeField] private float fadeDuration = 1f;

    private void Start()
    {
        buttonImage = creditsButton.GetComponent<Image>();

        menuArt.gameObject.SetActive(true);
        menuArt.alpha = 1f;

        credits.gameObject.SetActive(false);
        credits.alpha = 0f;
    }

    public void StartGame()
    {
        SceneManager.LoadScene(SceneOne);
    }

    public void GoToCredits()
    {
        if (inTransition) return;

        if (!showingCredits)
        {
            StartCoroutine(ViewChange(menuArt, credits));
            buttonImage.color = new Color32(227, 192, 121, 255);
            

        }
        else
        {
            StartCoroutine(ViewChange(credits, menuArt));
            buttonImage.color = Color.white;
        }

        showingCredits = !showingCredits;


    }

    public void ExitGame()
    {
        Application.Quit();
    }


    IEnumerator ViewChange(CanvasGroup fadeOutObject, CanvasGroup fadeInObject)
    {
        inTransition = true;

        yield return Fade(fadeOutObject, 1f, 0f);
        fadeOutObject.gameObject.SetActive(false);

        fadeInObject.alpha = 0f;
        fadeInObject.gameObject.SetActive(true);
        yield return Fade(fadeInObject, 0f, 1f);

        inTransition = false;
    }

    IEnumerator Fade(CanvasGroup group, float initAlpha, float targetAlpha)
    {
        float time = 0f;
        while(time < fadeDuration)
        {
            time += Time.deltaTime;
            group.alpha = Mathf.Lerp(initAlpha, targetAlpha, time / fadeDuration);
            yield return null;
        }

        group.alpha = targetAlpha;
    }


}
