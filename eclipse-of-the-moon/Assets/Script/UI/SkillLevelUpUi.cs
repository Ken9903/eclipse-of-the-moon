using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillLevelUpUi : MonoBehaviour
{
    private SkillManager skillManager;

    public Text nameText;
    public Text level;
    public Button button;

    public GameObject skill;

    public MagicPrepare magicPrepare;
    Player_Status player_Status;
    // Start is called before the first frame update
    void Start()
    {
        button.GetComponent<Button>().onClick.AddListener(delegate { OnClick(); });
        magicPrepare = GameObject.Find("MagicPrepare_L").GetComponent<MagicPrepare>();
        player_Status = GameObject.Find("Player").GetComponent<Player_Status>();
    }

    public void Init(GameObject name)
    {
        skillManager = GameObject.Find("SkillManager").GetComponent<SkillManager>(); // start에서 하면 skillManager가 널 오류.
        nameText.text = name.name;
        skill = name;
        level.text = skillManager.useAble[skill].ToString();
    }
    private void OnClick()
    {
        //플레이어 스테이터스에서 스킬포인트 조건검사. 전체 다 감싸 줘야함.
        if (skillManager.useAble[skill] < 10)
        {
            if(player_Status.skillPoint > 0)
            {
                skillManager.useAble[skill] = skillManager.useAble[skill] + 1;
                level.text = skillManager.useAble[skill].ToString(); //Ui 갱신
                player_Status.skillPoint--;

                int searchIndex = 0;
                foreach (GameObject current_skill in magicPrepare.magic)
                {
                    if (current_skill == skill)
                    {
                        magicPrepare.magicLevel[searchIndex] += 1;  // 방금 레벨을 올린 스킬이 현재 사용중이라면 그 정보도 업데이트.
                    }
                    searchIndex++;
                }

                Debug.Log(skill.name);
                Debug.Log(skillManager.useAble[skill]);
            }
           
        }
       
    }
}
