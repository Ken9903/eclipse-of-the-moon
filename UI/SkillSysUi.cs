using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillSysUi : MonoBehaviour
{
    public Text nameText;
    public Text costText;
    public Button button;
    public int cost;

    private GameObject tempUiObj;

    private SkillManager skillManager;

    private Player_Status player_Status;

    // Start is called before the first frame update
    public void Init(GameObject name,int cost)
    {
        nameText.text = name.name;
        costText.text = cost.ToString();
        tempUiObj = name;
        this.cost = cost;
    }

    private void Start()
    {
        button.GetComponent<Button>().onClick.AddListener(delegate { OnClick(); });
        skillManager = GameObject.Find("SkillManager").GetComponent<SkillManager>();
        Debug.Log(tempUiObj);
        this.transform.SetParent(GameObject.Find("ContentKakutoku").transform, false);

        player_Status = GameObject.Find("Player").GetComponent<Player_Status>();
    }

    private void OnClick()
    {
        if(player_Status.skillPoint >= cost)
        {
            player_Status.skillPoint -= cost;
            skillManager.useAble.Add(tempUiObj, 1);
            skillManager.kakutokuAble.Remove(tempUiObj);
            this.gameObject.SetActive(false);
            skillManager.UseAbleUiAdd(tempUiObj);
            skillManager.skillLevelUpUiAdd(tempUiObj);

            Debug.Log(tempUiObj.name);
            Debug.Log("½ºÅ³ È¹µæ");
        }
        

    }


}
