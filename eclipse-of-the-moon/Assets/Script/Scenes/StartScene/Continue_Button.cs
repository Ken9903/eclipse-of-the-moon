using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;

public class Continue_Button : MonoBehaviour
{
    public DataController controller;

    private void Start()
    {
        controller = GameObject.Find("DataController").GetComponent<DataController>();
    }
    public void Continue_btn()
    {
        string filePath = Application.persistentDataPath + controller.GameDataFileName;
        // 저장된 게임이 있다면 (씬네임으로 판단)
        if (controller.gameData.sceneName != null)
        {
            //controller.LoadGameData();
            SceneManager.LoadScene(controller.gameData.sceneName);
        }
        else //없다면 처음부터
        {
            SceneManager.LoadScene("DeadRiver");
        }

        
    }
}
