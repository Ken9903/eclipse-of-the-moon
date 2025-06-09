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
        GameObject.Find("XR Rig").GetComponent<InitPos>().sponePoint = nextSponePoint; // �� �̵��� ��ġ �ʱ�ȸ
        if(other.name == "Body")
        {
            SceneManager.LoadScene(nextScene);
        }
    }

   
}
