using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Answer : MonoBehaviour
{
    public bool isDone = false;
    [SerializeField] GameObject _round = null;

    public void Fill(List<Round> rounds)
    {
        foreach(Round r in rounds)
        {
            GameObject go = Instantiate(_round, this.transform, false);
            go.GetComponent<Round>().color = r.color;
            go.GetComponent<Round>().SetColor();
        }
    }

}
