using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerUi : MonoBehaviour
{
    public Scenario_Manager scenarioManager;

    public GameObject contentTower;
    public GameObject buttonUi;

    public GameObject portal;
    
    // Start is called before the first frame update
    void Start()
    {
        scenarioManager = GameObject.Find("Scenario Manager").GetComponent<Scenario_Manager>();

        for(int i = 1; i < scenarioManager.tower_Level_enable + 1; ++i)
        {
            GameObject uiprefab = Instantiate(buttonUi, contentTower.transform);
            uiprefab.GetComponent<TowerLevelUi>().level = i;
            uiprefab.GetComponent<TowerLevelUi>().portal = portal;
        }
    }
}
