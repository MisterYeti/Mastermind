using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorToGuess : MonoBehaviour
{
    private Image _image;

    public int nb = 0;

    private void Start()
    {
        _image = GetComponent<Image>();

        StartCoroutine(ChangeColorCoroutine());
    }

    IEnumerator ChangeColorCoroutine()
    {
        float currentTime = 0.0f;
        float duration = 0.5f;
        COLOR lastColor = COLOR.White;

        yield return new WaitForSeconds(nb * 0.2f);

        while (true)
        {
            while (currentTime < duration)
            {
                currentTime += Time.deltaTime;
                yield return null;
            }
            Array values = Enum.GetValues(typeof(COLOR));
            COLOR color = (COLOR)values.GetValue(UnityEngine.Random.Range(0, GameManager.Instance.nbColors));
            while (color == lastColor)
            {
                color = (COLOR)values.GetValue(UnityEngine.Random.Range(0, GameManager.Instance.nbColors));
            }

            lastColor = color;

            switch (color)
            {
                case COLOR.White:
                    _image.color = Color.white;
                    break;
                case COLOR.Black:
                    _image.color = Color.black;
                    break;
                case COLOR.Red:
                    _image.color = Color.red;
                    break;
                case COLOR.Blue:
                    _image.color = Color.blue;
                    break;
                case COLOR.Yellow:
                    _image.color = Color.yellow;
                    break;
                case COLOR.Green:
                    _image.color = Color.green;
                    break;
                case COLOR.Gray:
                    _image.color = Color.gray;
                    break;
                case COLOR.Cyan:
                    _image.color = Color.cyan;
                    break;
                default:
                    break;
            }


            currentTime = 0.0f;
        }
    }

}
