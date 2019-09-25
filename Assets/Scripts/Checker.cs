using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checker : MonoBehaviour
{

    public List<COLOR> colors = new List<COLOR>();

    [SerializeField] GameObject _correctPion = null, _perfectPion = null;
    [SerializeField] List<Transform> _parentsTransform = new List<Transform>();


    public void Initialize(int nbChoices,int nbPossibilities, bool multipleColors = false)
    {
        if (nbChoices > nbPossibilities)
        {
            multipleColors = true;
        }

        for (int i = 0; i < nbChoices; i++)
        {
            if (multipleColors)
            {
                Array values = Enum.GetValues(typeof(COLOR));
                colors.Add((COLOR)values.GetValue(UnityEngine.Random.Range(0, nbPossibilities)));
            }
            else
            {
                Array values = Enum.GetValues(typeof(COLOR));
                COLOR toAdd = (COLOR)values.GetValue(UnityEngine.Random.Range(0, nbPossibilities));

                while (colors.Contains(toAdd))
                {
                    toAdd = (COLOR)values.GetValue(UnityEngine.Random.Range(0, nbPossibilities));
                }

                colors.Add(toAdd);

            }
        }
    }

    public bool Fill(List<COLOR> colorsProp, int tryNumber)
    {
        int perfect = 0;
        int correct = 0;


        Dictionary<COLOR, int> ColorsNumberToGuess = new Dictionary<COLOR, int>();
        Dictionary<COLOR, int> ColorsNumberProp = new Dictionary<COLOR, int>();

        foreach (COLOR c in colors)
        {
            if (!ColorsNumberToGuess.ContainsKey(c))
            {
                ColorsNumberToGuess.Add(c, 1);
            }
            else
            {
                ColorsNumberToGuess[c] = ColorsNumberToGuess[c] + 1;
            }
        }

        foreach (COLOR c in colorsProp)
        {
            if (!ColorsNumberProp.ContainsKey(c))
            {
                ColorsNumberProp.Add(c, 1);
            }
            else
            {
                ColorsNumberProp[c] = ColorsNumberProp[c] + 1;
            }
        }

        foreach (KeyValuePair<COLOR, int> colorNb in ColorsNumberToGuess)
        {
            if (ColorsNumberProp.ContainsKey(colorNb.Key))
            {
                if (colorNb.Value > ColorsNumberProp[colorNb.Key])
                {
                    correct += ColorsNumberProp[colorNb.Key];
                }
                else
                {
                    correct += colorNb.Value;
                }
            }
        }

        for (int i = 0; i < colors.Count; i++)
        {
            if (colors[i] == colorsProp[i])
            {
                perfect += 1;
                correct -= 1;
            }
        }

        InstanciatePions(tryNumber, perfect, correct);

        Debug.Log("Perfect = " + perfect + " --- " + "Correct = " + correct);

        return perfect == colors.Count ? true : false;

    }

    private void InstanciatePions(int tryNumber, int perfect, int correct)
    {
        for (int i = 0; i < perfect; i++)
        {
            Instantiate(_perfectPion, _parentsTransform[tryNumber], false);
        }

        for (int i = 0; i < correct; i++)
        {
            Instantiate(_correctPion, _parentsTransform[tryNumber], false);
        }
    }
}
