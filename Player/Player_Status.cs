using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Status : MonoBehaviour 
{
    //정적 변수에대한 체크 필요 일단 바꿔놨음.
    public int player_Max_Hp = 200;
    public int player_Hp;
    public int player_Max_Mp = 100;
    public int player_Mp;
    public int attackPoint;
    public int player_Lv;
    public double player_Exp;
    public double require_LevelUp = 30;
    public float require_LevelUpPercent = 40;

    public int skillPoint;

    private HP_Ui_trans hp_Ui_Trans;

    public GameObject levelUpUi;
    public Transform levelUpUiPos;

    public bool isdead = false;

    public IEnumerator mpAutoHeal()
    {
        while(true)
        {
            if (player_Mp < player_Max_Mp)
            {
                player_Mp++;
            }
            yield return new WaitForSeconds(30);
        }
       

    }

    private void Awake()
    {
        hp_Ui_Trans = GameObject.Find("HP_Ui").GetComponent<HP_Ui_trans>();
        //set_hp_init();
    }

    private void Start()
    {
        StartCoroutine(mpAutoHeal());
    }
    public void set_hp_init()
    {
        player_Hp = player_Max_Hp;
        hp_Ui_Trans.trans_Hp_Ui_only(player_Max_Hp, player_Hp);
    }

    public void accept_Damage_Player(int damage, string type)
    {
        player_Hp = player_Hp - damage;
        hp_Ui_Trans.trans_Hp_Ui(player_Max_Hp, player_Hp, type);
        if(player_Hp <= 0 && isdead == false)
        {
            isdead = true;
            GameObject.Find("XR Rig").GetComponent<PlayerDead>().die();
        }

    }


    public void acquire_Exp(int exp)
    {
        player_Exp += exp;
        checkLevelUp();
    }
    public void checkLevelUp()
    {
        if(player_Exp > require_LevelUp)
        {
            player_Lv++;
            player_Max_Hp += 200;
            attackPoint += 20;
            skillPoint += 2;

            Instantiate(levelUpUi,levelUpUiPos);

            player_Exp = player_Exp - require_LevelUp;

            require_LevelUp += require_LevelUpPercent;

            Scenario_Manager scenario_Manager = GameObject.Find("Scenario Manager").GetComponent<Scenario_Manager>();
            scenario_Manager.check_towerLevel_ForLevel();
        }
    }

    public void levelUpUiShow()
    {
        Instantiate(levelUpUi,levelUpUiPos);
    }
}
