using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeCheck : MonoBehaviour
{

    IEnumerator time()
    {
        yield return new WaitForSeconds(20);
        Scenario_Manager scenario_Manager = GameObject.Find("Scenario Manager").GetComponent<Scenario_Manager>();
        scenario_Manager.timeCheck = true;
    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(time());
    }

    
}
