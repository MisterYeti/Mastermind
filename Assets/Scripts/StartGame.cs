using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    [SerializeField] ColorToGuess _colorToGuess = null;
    [SerializeField] Transform _parent = null;


    private void Start()
    {
        for (int i = 0; i < GameManager.Instance.nbChoices; i++)
        {
            ColorToGuess color = Instantiate(_colorToGuess.gameObject, _parent, false).GetComponent<ColorToGuess>();
            color.nb = i;
        }
    }
}
