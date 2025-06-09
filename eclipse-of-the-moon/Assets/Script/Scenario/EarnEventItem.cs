using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarnEventItem : MonoBehaviour
{
    Scenario_Manager scenarioManager;

    public GameObject destroyParticle;
    private void Start()
    {
        scenarioManager = GameObject.Find("Scenario Manager").GetComponent<Scenario_Manager>();
    }
    public void selected()
    {
        scenarioManager.eventItemIsEarned = true;
    }

    public void unSelected()
    {
        Instantiate(destroyParticle, this.transform.position, this.transform.rotation);
        Destroy(this.gameObject, 0.5f);
    }
}
