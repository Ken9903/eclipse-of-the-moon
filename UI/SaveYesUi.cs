using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveYesUi : MonoBehaviour
{
    public Button button;
    public GameObject complite;

    public string scene;
    public int initnum;
    // Start is called before the first frame update
    void Start()
    {
        button.GetComponent<Button>().onClick.AddListener(delegate { OnClick(); });
    }

    public void init(string name, int num)
    {
        scene = name;
        initnum = num;
    }

    private void OnClick()
    {
        DataController dataController = GameObject.Find("DataController").GetComponent<DataController>();
        dataController.gameData.sceneName = scene;
        dataController.gameData.playerPos = initnum;
        dataController.SaveGameData();

        complite.SetActive(true);
    }
}
