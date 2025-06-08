using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Teleport : MonoBehaviour
{
    public Transform point;

    public Transform npcPoint1;
    public Transform npcPoint2;

    public GameObject xrRig;

    private void Start()
    {
        xrRig = GameObject.Find("XR Rig");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Body")
        {
            xrRig.transform.position = point.position;
            xrRig.transform.rotation = point.rotation;

            NpcManagement npcManagement = xrRig.GetComponent<NpcManagement>();

            if(npcManagement.Luna == true)
            {
                npcManagement.currrentNPC1.GetComponent<FollowNPC>().enabled = false;
                npcManagement.currrentNPC1.GetComponent<NavMeshAgent>().enabled = false;  // ������Ʈ �����ִ� ���ϸ� �����Ǽ����� �۵����� ����.
                npcManagement.currrentNPC1.transform.position = npcPoint1.position;
                npcManagement.currrentNPC1.transform.rotation = npcPoint1.rotation;
                npcManagement.currrentNPC1.GetComponent<NavMeshAgent>().enabled = true;
                npcManagement.currrentNPC1.GetComponent<FollowNPC>().enabled = true;
                Debug.Log("NPC �̵�");
            }
            if(npcManagement.Npc == true)
            {
                npcManagement.currrentNPC2.GetComponent<FollowNPC>().enabled = false;
                npcManagement.currrentNPC2.GetComponent<NavMeshAgent>().enabled = false;
                npcManagement.currrentNPC2.transform.position = npcPoint2.position;
                npcManagement.currrentNPC2.transform.rotation = npcPoint2.rotation;
                npcManagement.currrentNPC2.GetComponent<NavMeshAgent>().enabled = true;
                npcManagement.currrentNPC2.GetComponent<FollowNPC>().enabled = true;
            }
        }
    }
}
