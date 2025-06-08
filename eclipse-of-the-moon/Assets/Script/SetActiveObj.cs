using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetActiveObj : MonoBehaviour
{
    public GameObject item;
    public GameObject skillManagerObj;
    void Start()
    {
        skillManagerObj = GameObject.Find("SkillManager");
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Body")
        {
            item.SetActive(true);
            skillManagerObj.transform.localScale = Vector3.one;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Body")
        {
            item.SetActive(false);
            skillManagerObj.transform.localScale= Vector3.zero;
        }
    }




}
