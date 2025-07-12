using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SchoolNpcSetActive : MonoBehaviour
{
    public string targetNpcName;

    public GameObject trigger;

    // Start is called before the first frame update
    void Start()
    {
        NpcManagement npcManagement = GameObject.Find("XR Rig").GetComponent<NpcManagement>();

        if(npcManagement.npcName == targetNpcName)
        {
            this.gameObject.SetActive(false);

            trigger.SetActive(false);
        } 
    }

    
}
