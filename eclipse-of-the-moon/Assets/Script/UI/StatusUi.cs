using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusUi : MonoBehaviour
{
    public Player_Status status;

    public Text lv;
    public Text exp;
    public Text hp;
    public Text mp;
    public Text skillPoint;

    

    private void OnEnable()
    {
        lv.text = "Lv : " + status.player_Lv.ToString();
        exp.text = "Exp : " + status.player_Exp.ToString() + "/" + status.require_LevelUp.ToString();
        hp.text = "Hp : " + status.player_Hp.ToString() + "/" + status.player_Max_Hp.ToString();
        mp.text = "Mp : " + status.player_Mp.ToString() + "/" + status.player_Max_Mp.ToString();
        skillPoint.text ="SkillPoint : " + status.skillPoint.ToString();     
    }
}
