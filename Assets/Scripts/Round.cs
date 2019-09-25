using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum COLOR
{
    White,
    Black,
    Red,
    Blue,
    Yellow,
    Green,
    Gray,
    Cyan
}

public class Round : MonoBehaviour
{
    public COLOR color;
    public int id;
    [SerializeField] private Image _image = null;

    public Round(COLOR color)
    {
        this.color = color;
    }

    public void InstanciateColor(int nb)
    {
        Array values = Enum.GetValues(typeof(COLOR));
        this.color = (COLOR)values.GetValue(nb);
        SetColor();
    }

    public void SetColor()
    {
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
    }
}
