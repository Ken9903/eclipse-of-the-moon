using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PassiveSkillLevelUp : MonoBehaviour
{
    public Text nameText;
    public Text level;
    public Button button;

    public string passiveName;
    public int passiveNumber;

    public MagicPrepare magicPrepare;
    Player_Status playerStatus;
    
    void Start()
    {
        button.GetComponent<Button>().onClick.AddListener(delegate { OnClick(); });
        magicPrepare = GameObject.Find("MagicPrepare_L").GetComponent<MagicPrepare>();
        playerStatus = GameObject.Find("Player").GetComponent<Player_Status>();

        Init();
    }

    public void Init()
    {
        nameText.text = passiveName;
        if(passiveNumber == 1)
        {
            level.text = magicPrepare.passive1Level.ToString();
        }
        else if(passiveNumber == 2)
        {
            level.text = magicPrepare.passive2Level.ToString();
        }
        else if(passiveNumber == 3)
        {
            level.text = magicPrepare.passive3Level.ToString();
        }
        
    }
    private void OnClick()
    {
        
        if(passiveNumber == 1)
        {
            //플레이어 스테이터스에서 스킬포인트 조건검사. 전체 다 감싸 줘야함.
            if(magicPrepare.passive1Level < 10)
            {
                if(playerStatus.skillPoint > 0)
                {
                    magicPrepare.passive1Level += 1;
                    level.text = magicPrepare.passive1Level.ToString();
                    playerStatus.skillPoint--;

                }
            }  
        }
        else if(passiveNumber == 2)
        {
            //플레이어 스테이터스에서 스킬포인트 조건검사. 전체 다 감싸 줘야함.
            if (magicPrepare.passive2Level < 10)
            {
                if (playerStatus.skillPoint > 0)
                {
                    magicPrepare.passive2Level += 1;
                    level.text = magicPrepare.passive2Level.ToString();
                    playerStatus.skillPoint--;
                }
            }
        }
        else if(passiveNumber == 3)
        {
            if (magicPrepare.passive3Level < 10)
            {
                if (playerStatus.skillPoint > 0)
                {
                    magicPrepare.passive3Level += 1;
                    level.text = magicPrepare.passive3Level.ToString();
                    playerStatus.skillPoint--;
                }
            }
        }
    }
}
