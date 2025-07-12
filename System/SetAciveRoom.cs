using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetAciveRoom : MonoBehaviour
{
    public GameObject item;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Body")
        {
            item.SetActive(true);
            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Body")
        {
            item.SetActive(false);
           
        }
    }
}
