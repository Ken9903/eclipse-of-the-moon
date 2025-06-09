using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillManager_Enable : MonoBehaviour
{
    public GameObject skillManagerObj;
    // Start is called before the first frame update
    void Start()
    {
        skillManagerObj = GameObject.Find("SkillManager");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Body")
        {
            skillManagerObj.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Body")
        {
            skillManagerObj.SetActive(false);
        }
    }
}
