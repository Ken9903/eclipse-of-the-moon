using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem;
using UnityEngine.SceneManagement;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR;
using UnityEngine.AI;
using System;

public class Scenario_Manager : MonoBehaviour
{
    public System.Single scenario_main_number = 0;
    public System.Single scenario_sub_number = 0;

    public System.Single tower_Level_enable = 0; //허용 가능 타워 레벨
    public System.Single current_tower_Level = 0; // 클리어 한 맥스 타워 레벨

    public bool eventItemIsEarned = false;
    public bool specialCrearCondition = false;

    public bool timeCheck = false;

    public Player_Status player_Status;


    private void Start()
    {
        player_Status = GameObject.Find("Player").GetComponent<Player_Status>();
    }


    public bool nextAble = true;

    private BoxCollider target_trigger;

    private IEnumerator coroutine_trigger_on_off;  //코루틴 stop함수를 위한 선언부.
    public IEnumerator Trigger_on_off(string target_name)
    {
        while (true)
        {
            if (target_trigger == null)
            {
                target_trigger = GameObject.Find(target_name).GetComponent<BoxCollider>();  //최적화를 위해 한번만 찾아줌.
            }
            target_trigger.enabled = false;
            yield return new WaitForSeconds(1);
            target_trigger.enabled = true;
            yield return new WaitForSeconds(1);
        }
    }
    





    public bool GetScenario(System.Single scenario_main_num, System.Single scenario_sub_num)
    {
        return scenario_main_num == scenario_main_number && scenario_sub_num == scenario_sub_number ;
    }
    public void Next_Main_Scenario()
    {
        scenario_main_number++;
    }
    public void Next_Sub_Scenario()
    {
        scenario_sub_number++;
    }
    public void Init_Sub_Scenario()
    {
        scenario_sub_number = 0;
    }


    public bool CheckEventItem()
    {
        return eventItemIsEarned;
    }
    public void InitEventItem()
    {
        eventItemIsEarned = false;
    }

    public bool checkTimeOut()
    {
        return timeCheck;
    }

    public bool CheckSpecialConditon()
    {
        return specialCrearCondition;
    }
    public void InitSpecialCondition()
    {
        specialCrearCondition = false;
    }
    


    public void MoveScene(string sceneName, System.Single nextSpownPoint) //씬 이동은 이름받아서 다양화 시킬 여지 있음.
    {
        InitPos initPos = GameObject.Find("XR Rig").GetComponent<InitPos>();
        initPos.sponePoint = (int)nextSpownPoint;
        SceneManager.LoadScene(sceneName);
    }
    public void Heal()
    {
        player_Status.set_hp_init();
        player_Status.player_Mp = player_Status.player_Max_Mp;
    }


    public void ExitTowerAtTime()
    {
        EnviromentTime enviromentTime = GameObject.Find("Enviroment_Manager").GetComponent<EnviromentTime>();
        if (enviromentTime.time == "morning")
        {
            enviromentTime.time = "day";

            InitPos initPos = GameObject.Find("XR Rig").GetComponent<InitPos>();
            initPos.sponePoint = 2;
            SceneManager.LoadScene("Field_day");
        }
        else if (enviromentTime.time == "day")
        {
            enviromentTime.time = "afternoon";

            InitPos initPos = GameObject.Find("XR Rig").GetComponent<InitPos>();
            initPos.sponePoint = 2;
            SceneManager.LoadScene("Field_afternoon");
        }
        else if(enviromentTime.time == "afternoon")
        {
            enviromentTime.time = "night";

            InitPos initPos = GameObject.Find("XR Rig").GetComponent<InitPos>();
            initPos.sponePoint = 2;
            SceneManager.LoadScene("Field_night");
        }
    }

    public void InitTime()
    {
        EnviromentTime enviromentTime = GameObject.Find("Enviroment_Manager").GetComponent<EnviromentTime>();

        enviromentTime.time = "morning";

        InitPos initPos = GameObject.Find("XR Rig").GetComponent<InitPos>();
        initPos.sponePoint = 1; //무조건 침대에서 변한다. 만약 여관 시스템 도입하면 수정.
        player_Status.set_hp_init();
        player_Status.player_Mp = player_Status.player_Max_Mp;
        SceneManager.LoadScene("School_morning"); // 여관 도입되면 수정.
    }
    public void InitTimeAtOutSide_nonScene()
    {
        EnviromentTime enviromentTime = GameObject.Find("Enviroment_Manager").GetComponent<EnviromentTime>();

        enviromentTime.time = "morning";

        InitPos initPos = GameObject.Find("XR Rig").GetComponent<InitPos>();
        initPos.sponePoint = 3;
        player_Status.set_hp_init();
        player_Status.player_Mp = player_Status.player_Max_Mp;
        SceneManager.LoadScene("Field_morning"); // 여관 도입되면 수정.
    }
    public void InitTimeAtOutSide_Scene()
    {
        player_Status.set_hp_init();
        player_Status.player_Mp = player_Status.player_Max_Mp;
    }

        public void start_trigger_on_off(string target_name)
    {
        coroutine_trigger_on_off = Trigger_on_off(target_name);
        StartCoroutine(coroutine_trigger_on_off);
    }
    public void stop_trigger_on_off()
    {
        target_trigger = null;
        StopCoroutine(coroutine_trigger_on_off);
    }

    public void stop_controllerInteraction()
    {
        TeleportationProvider teleportationProvider = GameObject.Find("XR Rig").GetComponent<TeleportationProvider>();

        teleportationProvider.enabled = false;
    }
    public void start_controllerInteraction()
    {
        TeleportationProvider teleportationProvider = GameObject.Find("XR Rig").GetComponent<TeleportationProvider>();

        teleportationProvider.enabled = true;
    }

    public void check_towerLevel (System.Single level) //62페이지에 논리 있음.
    {
        if(level > current_tower_Level)
        {
            current_tower_Level = level;
        }

        if(current_tower_Level < player_Status.player_Lv && current_tower_Level == tower_Level_enable)
        {
            tower_Level_enable++;
        }
    }
    public void check_towerLevel_ForLevel() //이건 등록 안함.
    {
        if(player_Status.player_Lv == current_tower_Level)
        {
            tower_Level_enable++;
        }
    }

    public bool check_playerLevel(System.Single level)
    {
        return player_Status.player_Lv >= level;
    }
    public bool check_crrentTowerLevel(System.Single level)
    {
        return this.current_tower_Level == level;
    }
    


    //NPC관련 스크립팅

    public void FollowNpc(string targetModelName)
    {
        GameObject targetNpc = GameObject.Find(targetModelName);
        NpcManagement npcManagement = GameObject.Find("XR Rig").GetComponent<NpcManagement>();

        //Luna, Npc bool값과 Npc이름만 잘 주면 잘 돌아감.
        if(targetModelName == "luna")
        {
            npcManagement.Luna = true;
        }
        if(targetModelName != "luna")
        {
            if(targetModelName == "model4_school") // 내부 if의 조건은 non씬에서 대려갈때 용.
            {
                GameObject.Find("model4_school").name = "model4";
                npcManagement.npcName = "model4";
                GameObject.Find("TeleportPoint_sopia").SetActive(false);
            }
            else if(targetModelName == "model6_school")
            {
                GameObject.Find("model6_school").name = "model6";
                npcManagement.npcName = "model6";
                GameObject.Find("TeleportPoint_noa").SetActive(false);
            }
            else if(targetModelName == "model7_school")
            {
                GameObject.Find("model7_school").name = "model7";
                npcManagement.npcName = "model7";
                GameObject.Find("TeleportPoint_alice").SetActive(false);
            }
            else
            {
                npcManagement.npcName = targetModelName;
            }

            npcManagement.Npc = true;

        }

        targetNpc.GetComponent<NavMeshAgent>().enabled = true;
        targetNpc.GetComponent<FollowNPC>().enabled = true;
        targetNpc.GetComponent<FollowNPC>().navOn = true;
    }
    public void NotFollowNpc(string targetModelName)
    {
        GameObject targetNpc = GameObject.Find(targetModelName);

        NpcManagement npcManagement = GameObject.Find("XR Rig").GetComponent<NpcManagement>();

        if (targetModelName == "luna")
        {
            npcManagement.Luna = false;
        }
        if (targetModelName != "luna")
        {
            npcManagement.Npc = false;
            npcManagement.npcName = null;
        }
        targetNpc.GetComponent<FollowNPC>().navOn = false;

        targetNpc.GetComponent<FollowNPC>().enabled = false;
        targetNpc.GetComponent<NavMeshAgent>().enabled = false;
    }
    

    //NPC 관련 스크립팅 - 현재 어떤 NPC가 같이 하고 있는지 모르는 상황에 사용


    public void MainNpcFollowInit()
    {
        NpcManagement npcManagement = GameObject.Find("XR Rig").GetComponent<NpcManagement>();

        if (GameObject.Find("luna") != null) //예외처리
        {
            GameObject targetNpc = GameObject.Find("luna");

            targetNpc.GetComponent<FollowNPC>().navOn = false;

            targetNpc.GetComponent<FollowNPC>().enabled = false;
            targetNpc.GetComponent<NavMeshAgent>().enabled = false;
        }
        else
        {
            Debug.Log("메인캐릭터가 존재 하지 않습니다. 매니저만 정보 변경 진행.");
        }

        npcManagement.Luna = false;

    }
    public void SubNpcFollowInit()
    {
        NpcManagement npcManagement = GameObject.Find("XR Rig").GetComponent<NpcManagement>();

        if(GameObject.Find(npcManagement.npcName) != null) //예외처리
        {
            GameObject targetNpc = GameObject.Find(npcManagement.npcName);

            Animator[] anim = targetNpc.GetComponentsInChildren<Animator>();
            foreach (Animator anim2 in anim)
            {
                try
                {
                    anim2.SetBool("Walk Forward", false);
                    anim2.SetTrigger("Idle");
                    Debug.Log("idle 변경");
                }catch(NullReferenceException ie)
                {
                    Debug.Log("다른 애니메이터 파라미터 지정");
                }
                //anim2.enabled = false;
            }
           

            targetNpc.GetComponent<FollowNPC>().navOn = false;

            targetNpc.GetComponent<FollowNPC>().enabled = false;
            targetNpc.GetComponent<NavMeshAgent>().enabled = false;
        }
        else
        {
            Debug.Log("서브캐릭터가 존재 하지 않습니다. 매니저만 정보 변경 진행.");
        }

        npcManagement.Npc = false;
        npcManagement.npcName = null;

    }

    public void LunaComeOnBad()
    {
        //팔로우 스탑 코루틴 - 설정해 놓은 목적지 잃기 않기 위함

        GameObject luna = GameObject.Find("luna");
       
        NavMeshAgent lunaNav = luna.GetComponent<NavMeshAgent>();

        Transform lunaPoint = GameObject.Find("LunaPoint").GetComponent<Transform>();

        lunaNav.enabled = false;

        GameObject spark = GameObject.Find("Sparks_luna");
        spark.SetActive(false);
        spark.SetActive(true);
        luna.transform.position = lunaPoint.position;
        luna.transform.rotation = lunaPoint.rotation;
        lunaNav.enabled = true;


        Transform playerLookAtPoint = GameObject.Find("Main Camera").transform;
        Vector3 look_At_player = new Vector3(playerLookAtPoint.position.x, this.transform.position.y, playerLookAtPoint.position.z);
        transform.LookAt(look_At_player);


    }






    //Main0

    public void spawnWave_0_4()
    {
        GameObject.Find("SpawnPoint").GetComponent<SpawnWave>().spawnMonster();
    }

    //Main1 condition

    public bool CheckObject(string objectName)
    {
        if(GameObject.Find(objectName) != null ) // 이름에 주의
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    //Main3
    
    public void DetachSopia()
    {
        GameObject sparksSopia = GameObject.Find("Sparks_sopia");
        GameObject sopia = GameObject.Find("model4");

        sparksSopia.transform.position = sopia.transform.position;
        sopia.SetActive(false);
        sparksSopia.SetActive(false);
        sparksSopia.SetActive(true);

    }


    //Main4

    public void SetEyeBlink()
    {
        Animation sopia = GameObject.Find("model4_scene").GetComponent<Animation>();
        sopia.clip = sopia.GetClip("model4_blink");
        sopia.Play();
    }
    public void SetAnimatorTrue()
    {
        GameObject.Find("model (3) 1").GetComponent<Animator>().enabled = true;
    }

    public void SetItemPos() //main5에서도 사용
    {
        Transform itemPos = GameObject.Find("ItemPos").GetComponent<Transform>();
        GameObject artipect = GameObject.Find("artipect");
        artipect.transform.position = itemPos.position;
    }

    //Main6

   public void Wave6_1()
    {
        Wave_1_Chapter6 wave_1_Chapter6 = GameObject.Find("SpawnPoint").GetComponent<Wave_1_Chapter6>();
        wave_1_Chapter6.playWave1();
    }
    public void Wave6_2()
    {
        Wave_1_Chapter6 wave_1_Chapter6 = GameObject.Find("SpawnPoint").GetComponent<Wave_1_Chapter6>();
        wave_1_Chapter6.playWave2();
    }
    public void Wave6_3()
    {
        Wave_1_Chapter6 wave_1_Chapter6 = GameObject.Find("SpawnPoint").GetComponent<Wave_1_Chapter6>();
        wave_1_Chapter6.playWave3();
    }










    private void OnEnable()
    {
        Lua.RegisterFunction("GetScenario", this, SymbolExtensions.GetMethodInfo(() => GetScenario((int)0,0)));
        Lua.RegisterFunction("Next_Main_Scenario", this, SymbolExtensions.GetMethodInfo(() => Next_Main_Scenario()));
        Lua.RegisterFunction("Next_Sub_Scenario", this, SymbolExtensions.GetMethodInfo(() => Next_Sub_Scenario()));
        Lua.RegisterFunction("Init_Sub_Scenario", this, SymbolExtensions.GetMethodInfo(() => Init_Sub_Scenario()));

        Lua.RegisterFunction("CheckEventItem", this, SymbolExtensions.GetMethodInfo(() => CheckEventItem()));

        Lua.RegisterFunction("checkTimeOut", this, SymbolExtensions.GetMethodInfo(() => checkTimeOut()));

        Lua.RegisterFunction("InitEventItem", this, SymbolExtensions.GetMethodInfo(() => InitEventItem()));

        Lua.RegisterFunction("CheckSpecialConditon", this, SymbolExtensions.GetMethodInfo(() => CheckSpecialConditon()));
        Lua.RegisterFunction("InitSpecialCondition", this, SymbolExtensions.GetMethodInfo(() => InitSpecialCondition()));

        Lua.RegisterFunction("MoveScene", this, SymbolExtensions.GetMethodInfo(() => MoveScene((string)"",(int)0)));
        Lua.RegisterFunction("Heal", this, SymbolExtensions.GetMethodInfo(() => Heal()));

        Lua.RegisterFunction("ExitTowerAtTime", this, SymbolExtensions.GetMethodInfo(() => ExitTowerAtTime()));
        Lua.RegisterFunction("InitTime", this, SymbolExtensions.GetMethodInfo(() => InitTime()));
        Lua.RegisterFunction("InitTimeAtOutSide_nonScene", this, SymbolExtensions.GetMethodInfo(() => InitTimeAtOutSide_nonScene()));
        Lua.RegisterFunction("InitTimeAtOutSide_Scene", this, SymbolExtensions.GetMethodInfo(() => InitTimeAtOutSide_Scene()));

        Lua.RegisterFunction("start_trigger_on_off", this, SymbolExtensions.GetMethodInfo(() => start_trigger_on_off((string)"")));
        Lua.RegisterFunction("stop_trigger_on_off", this, SymbolExtensions.GetMethodInfo(() => stop_trigger_on_off()));

        Lua.RegisterFunction("check_towerLevel", this, SymbolExtensions.GetMethodInfo(() => check_towerLevel((int)0)));

        Lua.RegisterFunction("check_playerLevel", this, SymbolExtensions.GetMethodInfo(() => check_playerLevel((int)0)));
        Lua.RegisterFunction("check_crrentTowerLevel", this, SymbolExtensions.GetMethodInfo(() => check_crrentTowerLevel((int)0)));

        Lua.RegisterFunction("stop_controllerInteraction", this, SymbolExtensions.GetMethodInfo(() => stop_controllerInteraction()));
        Lua.RegisterFunction("start_controllerInteraction", this, SymbolExtensions.GetMethodInfo(() => start_controllerInteraction()));

        Lua.RegisterFunction("FollowNpc", this, SymbolExtensions.GetMethodInfo(() => FollowNpc((string)"")));
        Lua.RegisterFunction("NotFollowNpc", this, SymbolExtensions.GetMethodInfo(() => NotFollowNpc((string)"")));
        Lua.RegisterFunction("MainNpcFollowInit", this, SymbolExtensions.GetMethodInfo(() => MainNpcFollowInit()));
        Lua.RegisterFunction("SubNpcFollowInit", this, SymbolExtensions.GetMethodInfo(() => SubNpcFollowInit()));

        Lua.RegisterFunction("LunaComeOnBad", this, SymbolExtensions.GetMethodInfo(() => LunaComeOnBad()));


        //Main0
        Lua.RegisterFunction("spawnWave_0_4", this, SymbolExtensions.GetMethodInfo(() => spawnWave_0_4()));

        //Main1
        Lua.RegisterFunction("CheckObject", this, SymbolExtensions.GetMethodInfo(() => CheckObject((string)"")));

        //Main3
        Lua.RegisterFunction("DetachSopia", this, SymbolExtensions.GetMethodInfo(() => DetachSopia()));

        //Main4
        Lua.RegisterFunction("SetEyeBlink", this, SymbolExtensions.GetMethodInfo(() => SetEyeBlink()));
        Lua.RegisterFunction("SetAnimatorTrue", this, SymbolExtensions.GetMethodInfo(() => SetAnimatorTrue()));
        Lua.RegisterFunction("SetItemPos", this, SymbolExtensions.GetMethodInfo(() => SetItemPos()));

        //Main6
        Lua.RegisterFunction("Wave6_1", this, SymbolExtensions.GetMethodInfo(() => Wave6_1()));
        Lua.RegisterFunction("Wave6_2", this, SymbolExtensions.GetMethodInfo(() => Wave6_2()));
        Lua.RegisterFunction("Wave6_3", this, SymbolExtensions.GetMethodInfo(() => Wave6_3()));


    }
    private void OnDisable()
    {
        Lua.UnregisterFunction("GetScenario");
        Lua.UnregisterFunction("Next_Main_Scenario");
        Lua.UnregisterFunction("Next_Sub_Scenario");
        Lua.UnregisterFunction("Init_Sub_Scenario");

        Lua.UnregisterFunction("CheckEventItem");

        Lua.UnregisterFunction("checkTimeOut");

        Lua.UnregisterFunction("InitEventItem");

        Lua.UnregisterFunction("CheckSpecialConditon");
        Lua.UnregisterFunction("InitSpecialCondition");


        Lua.UnregisterFunction("MoveScene");
        Lua.UnregisterFunction("Heal");


        Lua.UnregisterFunction("ExitTowerAtTime");
        Lua.UnregisterFunction("InitTime");
        Lua.UnregisterFunction("InitTimeAtOutSide_nonScene");
        Lua.UnregisterFunction("InitTimeAtOutSide_Scene");

        Lua.UnregisterFunction("start_trigger_on_off");
        Lua.UnregisterFunction("stop_trigger_on_off");

        Lua.UnregisterFunction("check_towerLevel");

        Lua.UnregisterFunction("check_playerLevel");
        Lua.UnregisterFunction("check_crrentTowerLevel");

        Lua.UnregisterFunction("stop_controllerInteraction");
        Lua.UnregisterFunction("start_controllerInteraction");

        Lua.UnregisterFunction("FollowNpc");
        Lua.UnregisterFunction("NotFollowNpc");
        Lua.UnregisterFunction("MainNpcFollowInit");
        Lua.UnregisterFunction("SubNpcFollowInit");

        Lua.UnregisterFunction("LunaComeOnBad");




        //Main0
        Lua.UnregisterFunction("spawnWave_0_4");

        //Main1
        Lua.UnregisterFunction("CheckObject");

        //Main3
        Lua.UnregisterFunction("DetachSopia");

        //Main4
        Lua.UnregisterFunction("SetEyeBlink");
        Lua.UnregisterFunction("SetAnimatorTrue");
        Lua.UnregisterFunction("SetItemPos");

        //Main6
        Lua.UnregisterFunction("Wave6_1");
        Lua.UnregisterFunction("Wave6_2");
        Lua.UnregisterFunction("Wave6_3");
    }

}
