using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.AI;

public class NpcManagement : MonoBehaviour
{
    InitPos xrRigInitPos;

    public GameObject LunaObj;

    public GameObject model3Obj;
    public GameObject model4Obj;
    public GameObject model5Obj;
    public GameObject model6Obj;
    public GameObject model7Obj;
    public GameObject model8Obj;
    public GameObject model9Obj;

    public bool Luna;
    public bool Npc;
    public string npcName = "";

    public GameObject currrentNPC1; //루나가 켜져있어야만 효과 발동
    public GameObject currrentNPC2; //NPC가 켜져있어야만 효과 발동



    private void Awake()
    {
        xrRigInitPos = GetComponent<InitPos>();      
    }
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (xrRigInitPos.sponePoint == 0)
        {
            GameObject NpcSponePoint_0_1 = GameObject.Find("NpcSponePoint_0_1");
            GameObject NpcSponePoint_0_2 = GameObject.Find("NpcSponePoint_0_2");

            if (Luna == true)
            {
                currrentNPC1 = Instantiate(LunaObj, NpcSponePoint_0_1.transform.position, NpcSponePoint_0_1.transform.rotation);
                currrentNPC1.name = "luna";
                currrentNPC1.GetComponent<NavMeshAgent>().enabled = true;
                currrentNPC1.GetComponent<FollowNPC>().enabled = true;
            }
            if (Npc == true)
            {
                if (npcName == "model3")
                {
                    currrentNPC2 = Instantiate(model3Obj, NpcSponePoint_0_2.transform.position, NpcSponePoint_0_2.transform.rotation);
                    currrentNPC2.name = "model3";
                }
                else if (npcName == "model4")
                {
                    currrentNPC2 = Instantiate(model4Obj, NpcSponePoint_0_2.transform.position, NpcSponePoint_0_2.transform.rotation);
                    currrentNPC2.name = "model4";
                }
                else if (npcName == "model5")
                {
                    currrentNPC2 = Instantiate(model5Obj, NpcSponePoint_0_2.transform.position, NpcSponePoint_0_2.transform.rotation);
                    currrentNPC2.name = "model5";
                }
                else if (npcName == "model6")
                {
                    currrentNPC2 = Instantiate(model6Obj, NpcSponePoint_0_2.transform.position, NpcSponePoint_0_2.transform.rotation);
                    currrentNPC2.name = "model6";
                }
                else if (npcName == "model7")
                {
                    currrentNPC2 = Instantiate(model7Obj, NpcSponePoint_0_2.transform.position, NpcSponePoint_0_2.transform.rotation);
                    currrentNPC2.name = "model7";
                }
                else if (npcName == "model8")
                {
                    currrentNPC2 = Instantiate(model8Obj, NpcSponePoint_0_2.transform.position, NpcSponePoint_0_2.transform.rotation);
                    currrentNPC2.name = "model8";
                }
                else if (npcName == "model9")
                {
                    currrentNPC2 = Instantiate(model9Obj, NpcSponePoint_0_2.transform.position, NpcSponePoint_0_2.transform.rotation);
                    currrentNPC2.name = "model9";
                }

                currrentNPC2.GetComponent<NavMeshAgent>().enabled = true;
                currrentNPC2.GetComponent<FollowNPC>().enabled = true;
            }
        }
        else if (xrRigInitPos.sponePoint == 1)
        {
            GameObject NpcSponePoint_1_1 = GameObject.Find("NpcSponePoint_1_1");
            GameObject NpcSponePoint_1_2 = GameObject.Find("NpcSponePoint_1_2");

            if (Luna == true)
            {
                currrentNPC1 = Instantiate(LunaObj, NpcSponePoint_1_1.transform.position, NpcSponePoint_1_1.transform.rotation);
                currrentNPC1.name = "luna";
                currrentNPC1.GetComponent<NavMeshAgent>().enabled = true;
                currrentNPC1.GetComponent<FollowNPC>().enabled = true;
            }
            if (Npc == true)
            {
                if (npcName == "model3")
                {
                    currrentNPC2 = Instantiate(model3Obj, NpcSponePoint_1_2.transform.position, NpcSponePoint_1_2.transform.rotation);
                    currrentNPC2.name = "model3";
                }
                else if (npcName == "model4")
                {
                    currrentNPC2 = Instantiate(model4Obj, NpcSponePoint_1_2.transform.position, NpcSponePoint_1_2.transform.rotation);
                    currrentNPC2.name = "model4";
                }
                else if (npcName == "model5")
                {
                    currrentNPC2 = Instantiate(model5Obj, NpcSponePoint_1_2.transform.position, NpcSponePoint_1_2.transform.rotation);
                    currrentNPC2.name = "model5";
                }
                else if (npcName == "model6")
                {
                    currrentNPC2 = Instantiate(model6Obj, NpcSponePoint_1_2.transform.position, NpcSponePoint_1_2.transform.rotation);
                    currrentNPC2.name = "model6";
                }
                else if (npcName == "model7")
                {
                    currrentNPC2 = Instantiate(model7Obj, NpcSponePoint_1_2.transform.position, NpcSponePoint_1_2.transform.rotation);
                    currrentNPC2.name = "model7";
                }
                else if (npcName == "model8")
                {
                    currrentNPC2 = Instantiate(model8Obj, NpcSponePoint_1_2.transform.position, NpcSponePoint_1_2.transform.rotation);
                    currrentNPC2.name = "model8";
                }
                else if (npcName == "model9")
                {
                    currrentNPC2 = Instantiate(model9Obj, NpcSponePoint_1_2.transform.position, NpcSponePoint_1_2.transform.rotation);
                    currrentNPC2.name = "model9";
                }

                currrentNPC2.GetComponent<NavMeshAgent>().enabled = true;
                currrentNPC2.GetComponent<FollowNPC>().enabled = true;
            }
        }
        else if (xrRigInitPos.sponePoint == 2)
        {
            GameObject NpcSponePoint_2_1 = GameObject.Find("NpcSponePoint_2_1");
            GameObject NpcSponePoint_2_2 = GameObject.Find("NpcSponePoint_2_2");

            if (Luna == true)
            {
                currrentNPC1 = Instantiate(LunaObj, NpcSponePoint_2_1.transform.position, NpcSponePoint_2_1.transform.rotation);
                currrentNPC1.name = "luna";
                currrentNPC1.GetComponent<NavMeshAgent>().enabled = true;
                currrentNPC1.GetComponent<FollowNPC>().enabled = true;
            }
            if (Npc == true)
            {
                if (npcName == "model3")
                {
                    currrentNPC2 = Instantiate(model3Obj, NpcSponePoint_2_2.transform.position, NpcSponePoint_2_2.transform.rotation);
                    currrentNPC2.name = "model3";
                }
                else if (npcName == "model4")
                {
                    currrentNPC2 = Instantiate(model4Obj, NpcSponePoint_2_2.transform.position, NpcSponePoint_2_2.transform.rotation);
                    currrentNPC2.name = "model4";
                }
                else if (npcName == "model5")
                {
                    currrentNPC2 = Instantiate(model5Obj, NpcSponePoint_2_2.transform.position, NpcSponePoint_2_2.transform.rotation);
                    currrentNPC2.name = "model5";
                }
                else if (npcName == "model6")
                {
                    currrentNPC2 = Instantiate(model6Obj, NpcSponePoint_2_2.transform.position, NpcSponePoint_2_2.transform.rotation);
                    currrentNPC2.name = "model6";
                }
                else if (npcName == "model7")
                {
                    currrentNPC2 = Instantiate(model7Obj, NpcSponePoint_2_2.transform.position, NpcSponePoint_2_2.transform.rotation);
                    currrentNPC2.name = "model7";
                }
                else if (npcName == "model8")
                {
                    currrentNPC2 = Instantiate(model8Obj, NpcSponePoint_2_2.transform.position, NpcSponePoint_2_2.transform.rotation);
                    currrentNPC2.name = "model8";
                }
                else if (npcName == "model9")
                {
                    currrentNPC2 = Instantiate(model9Obj, NpcSponePoint_2_2.transform.position, NpcSponePoint_2_2.transform.rotation);
                    currrentNPC2.name = "model9";
                }

                currrentNPC2.GetComponent<NavMeshAgent>().enabled = true;
                currrentNPC2.GetComponent<FollowNPC>().enabled = true;
            }
        }
        else if (xrRigInitPos.sponePoint == 3)
        {
            GameObject NpcSponePoint_3_1 = GameObject.Find("NpcSponePoint_3_1");
            GameObject NpcSponePoint_3_2 = GameObject.Find("NpcSponePoint_3_2");

            if (Luna == true)
            {
                currrentNPC1 = Instantiate(LunaObj, NpcSponePoint_3_1.transform.position, NpcSponePoint_3_1.transform.rotation);
                currrentNPC1.name = "luna";
                currrentNPC1.GetComponent<NavMeshAgent>().enabled = true;
                currrentNPC1.GetComponent<FollowNPC>().enabled = true;
            }
            if (Npc == true)
            {
                if (npcName == "model3")
                {
                    currrentNPC2 = Instantiate(model3Obj, NpcSponePoint_3_2.transform.position, NpcSponePoint_3_2.transform.rotation);
                    currrentNPC2.name = "model3";
                }
                else if (npcName == "model4")
                {
                    currrentNPC2 = Instantiate(model4Obj, NpcSponePoint_3_2.transform.position, NpcSponePoint_3_2.transform.rotation);
                    currrentNPC2.name = "model4";
                }
                else if (npcName == "model5")
                {
                    currrentNPC2 = Instantiate(model5Obj, NpcSponePoint_3_2.transform.position, NpcSponePoint_3_2.transform.rotation);
                    currrentNPC2.name = "model5";
                }
                else if (npcName == "model6")
                {
                    currrentNPC2 = Instantiate(model6Obj, NpcSponePoint_3_2.transform.position, NpcSponePoint_3_2.transform.rotation);
                    currrentNPC2.name = "model6";
                }
                else if (npcName == "model7")
                {
                    currrentNPC2 = Instantiate(model7Obj, NpcSponePoint_3_2.transform.position, NpcSponePoint_3_2.transform.rotation);
                    currrentNPC2.name = "model7";
                }
                else if (npcName == "model8")
                {
                    currrentNPC2 = Instantiate(model8Obj, NpcSponePoint_3_2.transform.position, NpcSponePoint_3_2.transform.rotation);
                    currrentNPC2.name = "model8";
                }
                else if (npcName == "model9")
                {
                    currrentNPC2 = Instantiate(model9Obj, NpcSponePoint_3_2.transform.position, NpcSponePoint_3_2.transform.rotation);
                    currrentNPC2.name = "model9";
                }

                currrentNPC2.GetComponent<NavMeshAgent>().enabled = true;
                currrentNPC2.GetComponent<FollowNPC>().enabled = true;
            }
        }
        else
        {
            Debug.Log("Npc 스폰지정 에러");
        }
        
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
