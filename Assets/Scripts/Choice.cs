using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI.Extensions;

public class Choice : MonoBehaviour
{
    public int id;
    public Round roundSelected;

    public VerticalScrollSnap vertical;

    private void Start()
    {
        OnSelectionChanged();
    }

    public void OnSelectionChanged()
    {
        roundSelected = vertical.ChildObjects[vertical.CurrentPage].GetComponent<Round>();
        GameManager.Instance.UpdateBoard(roundSelected);
    }

}
