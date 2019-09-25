using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<GameManager>();
            }

            return _instance;
        }
    }

    private Board _board;
    private Checker _checker;

    public List<Answer> answers;

    private int nbChoices = 4, nbColors = 6;
    private int tryNumber = 0;

    private void Start()
    {
        _board = FindObjectOfType<Board>();
        _checker = FindObjectOfType<Checker>();

        if (Settings.Instance)
        {
            _board.Instanciate(Settings.Instance.nbChoices, Settings.Instance.nbColors);
            _checker.Initialize(Settings.Instance.nbChoices, Settings.Instance.nbColors,Settings.Instance.duplicat);
        }
        else
        {
            _board.Instanciate(nbChoices, nbColors);
            _checker.Initialize(nbChoices, nbColors);
        }
        
    }

    public void UpdateBoard(Round roundSelected)
    {
        _board.Refresh(roundSelected);
    }

    public void Validate()
    {
        if (tryNumber < 12)
        {
            answers[tryNumber].Fill(_board.GetRounds());
            _checker.Fill(_board.GetCOLORS(), tryNumber);

            tryNumber += 1;
        }
    }

}
