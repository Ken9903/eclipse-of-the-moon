using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using PixelCrushers.DialogueSystem;

public class LanguegeButton : MonoBehaviour
{
    public string name;

    public Text mainText;
    
    public void OnClick()
    {
        mainText.text = name;
        DataController dataController = GameObject.Find("DataController").GetComponent<DataController>();
        dataController.gameData.languege = name;
        
        dataController.languegeSave();

        if (name == "Korean")
        {
            DialogueManager.SetLanguage("");
        }else if(name == "English")
        {
            DialogueManager.SetLanguage("en");
        }
    }
}
