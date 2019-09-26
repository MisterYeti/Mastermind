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
            return _instance;
        }
    }

    public int nbChoices = 4, nbColors = 6;
    public bool duplicat = false;

   


    private void Awake()
    {    
        if (Instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }


        DontDestroyOnLoad(this);      
    }
  
}
