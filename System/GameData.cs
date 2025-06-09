using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using PixelCrushers.DialogueSystem;

[Serializable] // ����ȭ

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
    public int passive1Level;  // 0�̸� ��Ȱ��ȭ.
    public int passive2Level;  // 0�̸� ��Ȱ��ȭ.
    public int passive3Level;  // 0�̸� ��Ȱ��ȭ.


    public System.Single scenario_main_number;
    public System.Single scenario_sub_number;

    public System.Single tower_Level_enable; //��� ���� Ÿ�� ����
    public System.Single current_tower_Level; // Ŭ���� �� �ƽ� Ÿ�� ����


    public string time;

    public List<string> kakutokuAbleObj = new List<string> ();
    public List<int> kakutokuAbleCost = new List<int> ();

    public List<string> useAbleObj = new List<string>();
    public List<int> useAbleLevel = new List<int>();

    public String sceneName; // ��κ� ��ġ ���⼭ ����
    public int playerPos; // �ʵ忡�� ���� ����


    public string languege = "Korean";

    
    
    
}