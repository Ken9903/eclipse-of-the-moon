using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using PixelCrushers.DialogueSystem;

[Serializable] // 직렬화

public class GameData
{
    public int player_Max_Hp;
    public int player_Hp;
    public int player_Mp;
    public int attackPoint;
    public int player_Lv;
    public double player_Exp;
    public double require_LevelUp;
    public int skillPoint;

    public bool luna;
    public bool npc;
    public string npcName;

    public string[] magic = new string[3];
    public int[] magicLevel = new int[3];
    public int passive1Level;  // 0이면 비활성화.
    public int passive2Level;  // 0이면 비활성화.
    public int passive3Level;  // 0이면 비활성화.


    public System.Single scenario_main_number;
    public System.Single scenario_sub_number;

    public System.Single tower_Level_enable; //허용 가능 타워 레벨
    public System.Single current_tower_Level; // 클리어 한 맥스 타워 레벨


    public string time;

    public List<string> kakutokuAbleObj = new List<string> ();
    public List<int> kakutokuAbleCost = new List<int> ();

    public List<string> useAbleObj = new List<string>();
    public List<int> useAbleLevel = new List<int>();

    public String sceneName; // 대부분 위치 여기서 구별
    public int playerPos; // 필드에서 여관 구별


    public string languege = "Korean";

    
    
    
}