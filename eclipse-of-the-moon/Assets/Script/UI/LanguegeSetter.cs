using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LanguegeSetter : MonoBehaviour
{
    public Text text;
    
    void Start()
    {
        DataController dataController = GameObject.Find("DataController").GetComponent<DataController>();
        text.text = dataController.gameData.languege;
    }

    
}
