using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
public class DataController : MonoBehaviour
{

    // ---�̱������� ����--- 
    static GameObject _container;
    static GameObject Container
    {
        get
        {
            return _container;
        }
    }
    static DataController _instance;
    public static DataController Instance
    {
        get
        {
            if (!_instance)
            {
                _container = new GameObject();
                _container.name = "DataController";
                _instance = _container.AddComponent(typeof(DataController)) as DataController;
                DontDestroyOnLoad(_container);
            }
            return _instance;
        }
    }

    // --- ���� ������ �����̸� ���� ---
    public string GameDataFileName = "Eclice.json";

    // "���ϴ� �̸�(����).json"
    public GameData _gameData;
    public GameData gameData
    {
        get
        {
            // ������ ���۵Ǹ� �ڵ����� ����ǵ���
            if (_gameData == null)
            {
                //LoadGameData();
                //SaveGameData();
            }
            return _gameData;
        }
    }

    private void Awake()
    {
        LoadGameData();
        //SaveGameData();
    }

    // ����� ���� �ҷ�����

    public void SceneInit() //���� ��ŸƮ or ����ŸƮ ��ư�� �Ҵ� ���� ��
    {
        SceneManager.LoadScene(gameData.sceneName);
    }
   
    public void LoadGameData()
    {
 
        string filePath = Application.persistentDataPath + GameDataFileName;
        Debug.Log(filePath);
        // ����� ������ �ִٸ�
        if (File.Exists(filePath))
        {
            print("�ҷ����� ����");
            string FromJsonData = File.ReadAllText(filePath);
            _gameData = JsonUtility.FromJson<GameData>(FromJsonData);


        }

        // ����� ������ ���ٸ�
        else
        {
            print("���ο� ���� ����");
            _gameData = new GameData();
            gameData.player_Max_Hp = 200;
            gameData.player_Hp = 200;
            gameData.player_Mp = 100;
            gameData.attackPoint = 20;
            gameData.player_Lv = 1;
            gameData.require_LevelUp = 30;

            gameData.magic[0] = "BasicShot";
            gameData.magic[1] = "EmptyMagic1";
            gameData.magic[2] = "EmptyMagic2";

            gameData.passive1Level = 1;
            gameData.passive2Level = 0;
            gameData.passive3Level = 0;

            gameData.magicLevel[0] = 1;

            gameData.tower_Level_enable = 1;

            gameData.time = "morning";

            gameData.sceneName = "DeadRiver";
            gameData.playerPos = 3;

        }

        GameObject player = GameObject.Find("Player");
        Player_Status player_Status = player.GetComponent<Player_Status>();
        player_Status.player_Max_Hp = gameData.player_Max_Hp;
        player_Status.player_Hp = gameData.player_Hp;
        player_Status.player_Mp = gameData.player_Mp;
        player_Status.attackPoint = gameData.attackPoint;
        player_Status.player_Lv = gameData.player_Lv;
        player_Status.player_Exp = gameData.player_Exp;
        player_Status.require_LevelUp = gameData.require_LevelUp;
        player_Status.skillPoint = gameData.skillPoint;

        GameObject xrRig = GameObject.Find("XR Rig");
        NpcManagement npcManagement = xrRig.GetComponent<NpcManagement>();
        npcManagement.Luna = gameData.luna;
        npcManagement.Npc = gameData.npc;
        npcManagement.npcName = gameData.npcName;

        InitPos initPos = xrRig.GetComponent<InitPos>();




    
        initPos.sponePoint = 3; 
       



        MagicPrepare magicPrepare = player.GetComponentInChildren<MagicPrepare>();
        magicPrepare.magic[0] = Resources.Load<GameObject>(gameData.magic[0]);
        magicPrepare.magic[1] = Resources.Load<GameObject>(gameData.magic[1]);
        magicPrepare.magic[2] = Resources.Load<GameObject>(gameData.magic[2]);
        magicPrepare.magicLevel = gameData.magicLevel;
        magicPrepare.passive1Level = gameData.passive1Level;
        magicPrepare.passive2Level = gameData.passive2Level;
        magicPrepare.passive3Level = gameData.passive3Level;

        Scenario_Manager scenario_Manager = GameObject.Find("Scenario Manager").GetComponent<Scenario_Manager>();
        scenario_Manager.scenario_main_number = gameData.scenario_main_number;
        scenario_Manager.scenario_sub_number = gameData.scenario_sub_number;
        scenario_Manager.tower_Level_enable = gameData.tower_Level_enable;
        scenario_Manager.current_tower_Level = gameData.current_tower_Level;

        EnviromentTime enviromentTime = GameObject.Find("Enviroment_Manager").GetComponent<EnviromentTime>();
        enviromentTime.time = gameData.time;

        SkillManager skillManager = GameObject.Find("SkillManager").GetComponent<SkillManager>();
        skillManager.useAble.Clear();
        skillManager.kakutokuAble.Clear();
        skillManager.skillInit();
        for (int i = 0; i < gameData.kakutokuAbleObj.Count; i++)
        {
            skillManager.kakutokuAble.Add(Resources.Load<GameObject>(gameData.kakutokuAbleObj[i]), gameData.kakutokuAbleCost[i]);
        }
        for (int i = 0; i < gameData.useAbleObj.Count; i++)
        {
            skillManager.useAble.Add(Resources.Load<GameObject>(gameData.useAbleObj[i]), gameData.useAbleLevel[i]);
        }





    }

    // ���� �����ϱ�
    public void SaveGameData()
    {
        //�÷��̾�
        GameObject player = GameObject.Find("Player");
        Player_Status player_Status = player.GetComponent<Player_Status>();
        gameData.player_Max_Hp = player_Status.player_Max_Hp;
        gameData.player_Hp = player_Status.player_Hp;
        gameData.player_Mp = player_Status.player_Mp;
        gameData.attackPoint = player_Status.attackPoint;
        gameData.player_Lv = player_Status.player_Lv;
        gameData.player_Exp = player_Status.player_Exp;
        gameData.require_LevelUp = player_Status.require_LevelUp;
        gameData.skillPoint = player_Status.skillPoint;

        //���ǽ� �Ŵ���
        NpcManagement npcManagement = GameObject.Find("XR Rig").GetComponent<NpcManagement>();
        gameData.luna = npcManagement.Luna;
        gameData.npc = npcManagement.Npc;
        gameData.npcName = npcManagement.npcName;



        //���� �������
        MagicPrepare magicPrepare = player.GetComponentInChildren<MagicPrepare>();
        gameData.magic[0] = magicPrepare.magic[0].name;
        gameData.magic[1] = magicPrepare.magic[1].name;
        gameData.magic[2] = magicPrepare.magic[2].name;

        gameData.magicLevel = magicPrepare.magicLevel;
        gameData.passive1Level = magicPrepare.passive1Level;
        gameData.passive2Level = magicPrepare.passive2Level;
        gameData.passive3Level = magicPrepare.passive3Level;

        //�ó����� �Ŵ���
        Scenario_Manager scenario_Manager = GameObject.Find("Scenario Manager").GetComponent<Scenario_Manager>();
        gameData.scenario_main_number = scenario_Manager.scenario_main_number;
        gameData.scenario_sub_number = scenario_Manager.scenario_sub_number;
        gameData.tower_Level_enable = scenario_Manager.tower_Level_enable;
        gameData.current_tower_Level = scenario_Manager.current_tower_Level;

        //�����̷θ�Ʈ �Ŵ���
        EnviromentTime enviromentTime = GameObject.Find("Enviroment_Manager").GetComponent<EnviromentTime>();
        gameData.time = enviromentTime.time;

        //��ų�Ŵ���
        SkillManager skillManager = GameObject.Find("SkillManager").GetComponent<SkillManager>();
        gameData.kakutokuAbleObj.Clear();
        gameData.kakutokuAbleCost.Clear();
        foreach (KeyValuePair<GameObject, int> item in skillManager.kakutokuAble)
        {
            gameData.kakutokuAbleObj.Add(item.Key.name);
            gameData.kakutokuAbleCost.Add(item.Value);
        }
        gameData.useAbleLevel.Clear();
        gameData.useAbleObj.Clear();
        foreach (KeyValuePair<GameObject, int> item in skillManager.useAble)
        {
            gameData.useAbleObj.Add(item.Key.name);
            gameData.useAbleLevel.Add(item.Value);
        }


        
        //�����Ӱ� ����� ��Ŭ���� �Ҵ� ��

        string ToJsonData = JsonUtility.ToJson(gameData);
        string filePath = Application.persistentDataPath + GameDataFileName;

        // �̹� ����� ������ �ִٸ� �����
        File.WriteAllText(filePath, ToJsonData);


        print("����Ϸ�");

    }

    public void languegeSave()
    {

        string ToJsonData = JsonUtility.ToJson(gameData);
        string filePath = Application.persistentDataPath + GameDataFileName;

        // �̹� ����� ������ �ִٸ� �����
        File.WriteAllText(filePath, ToJsonData);


        print("������ ����Ϸ�");
    }

    
}