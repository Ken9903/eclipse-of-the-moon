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
            Debug.Log("스폰포인트 0");    

        }
        else if(sponePoint == 1)
        {
            Transform sponePointTransform = GameObject.Find("SponePoint1").GetComponent<Transform>();

            XRRig.transform.position = sponePointTransform.position;
            XRRig.transform.rotation = sponePointTransform.rotation;
            Debug.Log("스폰포인트 1");
        }
        else if (sponePoint == 2)
        {
            Transform sponePointTransform = GameObject.Find("SponePoint2").GetComponent<Transform>();

            XRRig.transform.position = sponePointTransform.position;
            XRRig.transform.rotation = sponePointTransform.rotation;
            Debug.Log("스폰포인트 2");
        }
        else if(sponePoint == 3)
        {
            Transform sponePointTransform = GameObject.Find("SponePoint3").GetComponent<Transform>();

            XRRig.transform.position = sponePointTransform.position;
            XRRig.transform.rotation = sponePointTransform.rotation;
            Debug.Log("스폰포인트 3");
        }
        Debug.Log("스폰 초기화 실행");

        //this.gameObject.SetActive(false);
        //this.gameObject.SetActive(true); //버그 조심. 씬 체인지 되고 XR RIg가 껐다 안 켜지면 다이얼로그매니저와 인터렉트브 불가 이슈

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
