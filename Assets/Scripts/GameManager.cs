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
    public Checker _checker;
    private EndGame _endGame;

    public List<Answer> answers;

    public int nbChoices = 4, nbColors = 6;
    public int tryNumber = 0;
    public bool hasWin = false;

    private void Start()
    {
        _board = FindObjectOfType<Board>();
        _checker = FindObjectOfType<Checker>();
        _endGame = FindObjectOfType<EndGame>();

        if (Settings.Instance)
        {
            nbChoices = Settings.Instance.nbChoices;
            nbColors = Settings.Instance.nbColors;

            _board.Instanciate(nbChoices, nbColors);
            _checker.Initialize(nbChoices, nbColors, Settings.Instance.duplicat);
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
            hasWin = _checker.Fill(_board.GetCOLORS(), tryNumber);

            tryNumber += 1;
        }
        if (tryNumber >= 12 && !hasWin)
        {
            _endGame.InstanciateEndGame(hasWin);
        }
        if (hasWin)
        {
            _endGame.InstanciateEndGame(hasWin);
        }
    }

}
