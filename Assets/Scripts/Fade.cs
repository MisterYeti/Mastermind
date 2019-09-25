using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fade : MonoBehaviour
{

    [SerializeField] CanvasGroup canvasToFadeIn;
    [SerializeField] CanvasGroup canvasToFadeOut;

    [SerializeField] bool startScene = false;

    private void Start()
    {
        if (startScene)
        {
            StartMastermind();
        }

    }


    public void FadeCanvases()
    {
        StartCoroutine(FadeCanvasesCoroutine());
    }

    public void StartMastermind()
    {
        StartCoroutine(FadeAndStartMastermindCoroutine());
    }

    public void StartGame(int scene)
    {
        StartCoroutine(FadeAndPlayCoroutine(scene));
    }

    public void QuitGame()
    {
        StartCoroutine(FadeAndQuitCoroutine());
    }

    private IEnumerator FadeCanvasesCoroutine()
    {
        float currentTime = 0.0f;
        float duration = 1.0f;
        var start = 1.0f; var end = 0.0f;


        canvasToFadeOut.blocksRaycasts = false;
        while (currentTime < duration)
        {
            currentTime += Time.deltaTime;
            var newVal = Mathf.Lerp(start, end, currentTime / duration);

            canvasToFadeOut.alpha = newVal;
            yield return null;
        }
        canvasToFadeOut.alpha = end;

        currentTime = 0.0f;
        duration = 1.0f;
        start = 0.0f; end = 1.0f;

        while (currentTime < duration)
        {
            currentTime += Time.deltaTime;
            var newVal = Mathf.Lerp(start, end, currentTime / duration);

            canvasToFadeIn.alpha = newVal;
            yield return null;
        }
        canvasToFadeIn.alpha = end;
        canvasToFadeIn.blocksRaycasts = true;
    }



    private IEnumerator FadeAndPlayCoroutine(int scene)
    {
        float currentTime = 0.0f;
        float duration = 1.0f;
        var start = 1.0f; var end = 0.0f;


        canvasToFadeOut.blocksRaycasts = false;
        while (currentTime < duration)
        {
            currentTime += Time.deltaTime;
            var newVal = Mathf.Lerp(start, end, currentTime / duration);

            canvasToFadeOut.alpha = newVal;
            yield return null;
        }
        canvasToFadeOut.alpha = end;

        SceneManager.LoadScene(scene);

    }

    private IEnumerator FadeAndQuitCoroutine()
    {
        float currentTime = 0.0f;
        float duration = 1.0f;
        var start = 1.0f; var end = 0.0f;


        canvasToFadeOut.blocksRaycasts = false;
        while (currentTime < duration)
        {
            currentTime += Time.deltaTime;
            var newVal = Mathf.Lerp(start, end, currentTime / duration);

            canvasToFadeOut.alpha = newVal;
            yield return null;
        }
        canvasToFadeOut.alpha = end;


        Application.Quit();
    }

    private IEnumerator FadeAndStartMastermindCoroutine()
    {
        float currentTime = 0.0f;
        float duration = 2.0f;
        var start = 0.0f; var end = 1.0f;

        canvasToFadeIn.alpha = 0.0f;
        canvasToFadeIn.blocksRaycasts = false;


        while (currentTime < duration)
        {
            currentTime += Time.deltaTime;
            var newVal = Mathf.Lerp(start, end, currentTime / duration);

            canvasToFadeIn.alpha = newVal;
            yield return null;
        }
        canvasToFadeIn.alpha = end;
        canvasToFadeIn.blocksRaycasts = true;
    }
}
