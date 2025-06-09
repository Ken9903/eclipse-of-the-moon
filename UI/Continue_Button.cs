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
        // ����� ������ �ִٸ� (���������� �Ǵ�)
        if (controller.gameData.sceneName != null)
        {
            //controller.LoadGameData();
            SceneManager.LoadScene(controller.gameData.sceneName);
        }
        else //���ٸ� ó������
        {
            SceneManager.LoadScene("DeadRiver");
        }

        
    }
}
