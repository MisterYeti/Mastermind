using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetSettings : MonoBehaviour
{
    Slider _sliderLenght = null;
    Slider _sliderNumber = null;
    Toggle _toggle = null;

    private void Start()
    {
        _sliderLenght = GameObject.FindGameObjectWithTag("sliderLenght").GetComponent<Slider>();
        _sliderNumber = GameObject.FindGameObjectWithTag("sliderNumber").GetComponent<Slider>();
        _toggle = GameObject.FindGameObjectWithTag("toggle").GetComponent<Toggle>();

        _sliderLenght.value = Settings.Instance.nbChoices;
        _sliderNumber.value = Settings.Instance.nbColors;
        _toggle.isOn = Settings.Instance.duplicat;
    }


    public void OnValueChangedLenght(TMPro.TextMeshProUGUI text)
    {
        text.text = _sliderLenght.value.ToString();
        Settings.Instance.nbChoices = (int)_sliderLenght.value;
    }

    public void OnValueChangedNumber(TMPro.TextMeshProUGUI text)
    {
        text.text = _sliderNumber.value.ToString();
        Settings.Instance.nbColors = (int)_sliderNumber.value;

    }

    public void OnValueTogglerChanged()
    {
        Settings.Instance.duplicat = _toggle.isOn;
    }
}
