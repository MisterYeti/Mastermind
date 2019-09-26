using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI.Extensions;

public class Board : MonoBehaviour
{
    public List<Choice> choices = new List<Choice>();
    [SerializeField] private Transform _parentProps = null;
    [SerializeField] private GameObject _choice = null;
    [SerializeField] private GameObject _propsRound = null;

    public void Instanciate(int nbChoice,int nbProps)
    {

        for (int i = 0; i < nbChoice; i++)
        {

            Transform choice = Instantiate(_choice, _parentProps, false).transform;
            choice.GetComponent<Choice>().id = i;
            choice.GetComponent<Choice>().vertical.GetComponent<ScrollSnapBase>().ChildObjects = new GameObject[nbProps];

            choices.Add(choice.GetComponent<Choice>());
            choice.GetComponent<Choice>().vertical.GetComponent<ScrollSnapBase>().StartingScreen = (int)(Mathf.Ceil(nbProps / 2));


            for (int y = 0; y < nbProps; y++)
            {
                GameObject round = Instantiate(_propsRound, choice.GetChild(0), false);
                choice.GetComponent<Choice>().vertical.GetComponent<ScrollSnapBase>().ChildObjects[y] = round;
                round.GetComponent<Round>().id = choice.GetComponent<Choice>().id;
                round.GetComponent<Round>().InstanciateColor(y);
            }
        }
    }

    public void Refresh(Round round)
    {
        foreach (Choice c in choices)
        {
            if (c.roundSelected != null && c.roundSelected.id == round.id)
            {
                c.roundSelected.color = round.color;
            }
        }
    }

    public List<Round> GetRounds()
    {
        List<Round> toReturn = new List<Round>();
        foreach (Choice c in choices)
        {
            toReturn.Add(c.roundSelected);
        }
        return toReturn;
    }

    public List<COLOR> GetCOLORS()
    {
        List<COLOR> toReturn = new List<COLOR>();
        foreach (Round r in GetRounds())
        {
            toReturn.Add(r.color);
        }
        return toReturn;
    }
}
