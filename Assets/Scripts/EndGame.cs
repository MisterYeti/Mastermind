using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndGame : MonoBehaviour
{

    private List<COLOR> colors = new List<COLOR>();
    [SerializeField] GameObject _color = null;

    [SerializeField] CanvasGroup _panel = null;
    [SerializeField] Transform _parent = null;

    [SerializeField] TMPro.TextMeshProUGUI txtCongratz = null, txtGuess = null;

    private void Start()
    {
        colors = GameManager.Instance._checker.colors;
    }

    public void InstanciateEndGame(bool win)
    {
        StartCoroutine(ShowPanel());
        if (!win)
        {
            txtCongratz.text = "You've failed..!";
            txtGuess.text = "The right code was :";
        }

        foreach (COLOR c in colors)
        {
            Image image = Instantiate(_color, _parent, false).GetComponent<Image>();
            switch (c)
            {
                case COLOR.White:
                    image.color = Color.white;
                    break;
                case COLOR.Black:
                    image.color = Color.black;
                    break;
                case COLOR.Red:
                    image.color = Color.red;
                    break;
                case COLOR.Blue:
                    image.color = Color.blue;
                    break;
                case COLOR.Yellow:
                    image.color = Color.yellow;
                    break;
                case COLOR.Green:
                    image.color = Color.green;
                    break;
                case COLOR.Gray:
                    image.color = Color.gray;
                    break;
                case COLOR.Cyan:
                    image.color = Color.cyan;
                    break;
                default:
                    break;
            }
        }
    }

    private IEnumerator ShowPanel()
    {
        _panel.blocksRaycasts = true;
        float currentTime = 0.0f;
        float duration = 1.0f;
        var start = 0.0f; var end = 1.0f;

        _panel.alpha = 0.0f;


        while (currentTime < duration)
        {
            currentTime += Time.deltaTime;
            var newVal = Mathf.Lerp(start, end, currentTime / duration);

            _panel.alpha = newVal;
            yield return null;
        }

        _panel.alpha = end;
        _panel.blocksRaycasts = true;
    }

}
