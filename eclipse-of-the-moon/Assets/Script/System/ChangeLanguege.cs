using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem;
public class ChangeLanguege : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        DataController dataController = GameObject.Find("DataController").GetComponent<DataController>();

        if (dataController.gameData.languege == "Korean")
        {
            DialogueManager.SetLanguage("");
        }
        else if (dataController.gameData.languege == "English")
        {
            DialogueManager.SetLanguage("en");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
