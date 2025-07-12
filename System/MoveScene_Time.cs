using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveScene_Time : MonoBehaviour
{
    public string[] nextScene;
    EnviromentTime enviromentTime;

    public int nextSponePoint;

    private void Start()
    {
        enviromentTime = GameObject.Find("Enviroment_Manager").GetComponent<EnviromentTime>();
    }

    private void OnTriggerEnter(Collider other)
    { 
        if(other.name == "Body")
        {
            GameObject.Find("XR Rig").GetComponent<InitPos>().sponePoint = nextSponePoint;

            if (enviromentTime.time == "morning")
            {
                SceneManager.LoadScene(nextScene[0]);
            }
            else if(enviromentTime.time == "day")
            {
                SceneManager.LoadScene(nextScene[1]);
            }
            else if (enviromentTime.time == "afternoon")
            {
                SceneManager.LoadScene(nextScene[2]);
            }
            else if (enviromentTime.time == "night")
            {
                SceneManager.LoadScene(nextScene[3]);
            }
        }
        
    }

}
