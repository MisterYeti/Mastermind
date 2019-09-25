using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    public static Settings _instance;
    public static Settings Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<Settings>();
            }

            return _instance;
        }
    }

    public int nbChoices, nbColors;
    public bool duplicat;

    [SerializeField] Slider _sliderLenght = null;
    [SerializeField] Slider _sliderNumber = null;
    [SerializeField] Toggle _toggle = null;


    private void Awake()
    {
        DontDestroyOnLoad(this);
        nbChoices = (int)_sliderLenght.value;
        nbColors = (int)_sliderNumber.value;
        duplicat = (bool)_toggle.isOn;
    }

    public void OnValueChangedLenght(TMPro.TextMeshProUGUI text)
    {
        text.text = _sliderLenght.value.ToString();
        nbChoices = (int)_sliderLenght.value;
    }

    public void OnValueChangedNumber(TMPro.TextMeshProUGUI text)
    {
        text.text = _sliderNumber.value.ToString();
        nbColors = (int)_sliderNumber.value;

    }

    public void OnValueTogglerChanged()
    {
        duplicat = _toggle.isOn;
    }
}
