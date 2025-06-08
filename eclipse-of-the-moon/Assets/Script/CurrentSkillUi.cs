using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrentSkillUi : MonoBehaviour
{
    private SkillManager skillManager;
    private MagicPrepare magicPrepare;

    public Text nameText;
    public Button button;

    public int tempIndex;
    // Start is called before the first frame update
    void Start()
    {
        button.GetComponent<Button>().onClick.AddListener(delegate { OnClick(); });
        skillManager = GameObject.Find("SkillManager").GetComponent<SkillManager>();
        magicPrepare = GameObject.Find("MagicPrepare_L").GetComponent<MagicPrepare>();
    }

    public void Init(int index, GameObject name) // index = 0 or 1 or 2
    {
        nameText.text = name.name;
        tempIndex = index;
    }
    private void OnClick()
    {
        if(skillManager.tempApplyMagic != null)
        {
            bool overlap = false;
            foreach(GameObject item in skillManager.currentMagic.Values)
            {
                if(item == skillManager.tempApplyMagic)
                {
                    overlap = true;
                }
            }
            if(overlap == false) // 현재 사용 스킬중에 중복이 되지않는 다면
            {
                nameText.text = skillManager.tempApplyMagic.name; //UI갱신

                skillManager.currentMagic[tempIndex] = skillManager.tempApplyMagic;
                magicPrepare.magic[tempIndex] = skillManager.tempApplyMagic;
                magicPrepare.magicLevel[tempIndex] = skillManager.useAble[skillManager.tempApplyMagic];
            }
           
        }
       
    }
}
