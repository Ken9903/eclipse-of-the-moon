using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public string nextScene;

    public int nextSponePoint;
    private void OnTriggerEnter(Collider other)
    {
        GameObject.Find("XR Rig").GetComponent<InitPos>().sponePoint = nextSponePoint; // 씬 이동후 위치 초기회
        if(other.name == "Body")
        {
            SceneManager.LoadScene(nextScene);
        }
    }

   
}
