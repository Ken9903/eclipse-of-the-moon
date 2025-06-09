using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InitPos : MonoBehaviour
{
    public int sponePoint;
    public Transform XRRig;


    

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if(sponePoint == 0)
        {
            Transform sponePointTransform = GameObject.Find("SponePoint0").GetComponent<Transform>();

            XRRig.transform.position = sponePointTransform.position;
            XRRig.transform.rotation = sponePointTransform.rotation;
            Debug.Log("��������Ʈ 0");    

        }
        else if(sponePoint == 1)
        {
            Transform sponePointTransform = GameObject.Find("SponePoint1").GetComponent<Transform>();

            XRRig.transform.position = sponePointTransform.position;
            XRRig.transform.rotation = sponePointTransform.rotation;
            Debug.Log("��������Ʈ 1");
        }
        else if (sponePoint == 2)
        {
            Transform sponePointTransform = GameObject.Find("SponePoint2").GetComponent<Transform>();

            XRRig.transform.position = sponePointTransform.position;
            XRRig.transform.rotation = sponePointTransform.rotation;
            Debug.Log("��������Ʈ 2");
        }
        else if(sponePoint == 3)
        {
            Transform sponePointTransform = GameObject.Find("SponePoint3").GetComponent<Transform>();

            XRRig.transform.position = sponePointTransform.position;
            XRRig.transform.rotation = sponePointTransform.rotation;
            Debug.Log("��������Ʈ 3");
        }
        Debug.Log("���� �ʱ�ȭ ����");

        //this.gameObject.SetActive(false);
        //this.gameObject.SetActive(true); //���� ����. �� ü���� �ǰ� XR RIg�� ���� �� ������ ���̾�α׸Ŵ����� ���ͷ�Ʈ�� �Ұ� �̽�

    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

}
