using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RapidShot : MonoBehaviour
{
    private Transform rapidPosition;
    public GameObject rapidShot_main;
    // Start is called before the first frame update
    void Start()
    {
        rapidPosition = GameObject.Find("FirePoint").GetComponent<Transform>();
        GameObject rapidShot = Instantiate(rapidShot_main, rapidPosition.transform);
        rapidShot.transform.SetParent(rapidPosition);
    }

   
}
