using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SkillManager : MonoBehaviour
{
    public Dictionary<GameObject, int> EarnedAble = new Dictionary<GameObject, int> (); //획득가능 변수        
    public Dictionary<GameObject, int> useAble = new Dictionary<GameObject, int>();  //사용가능 변수  오브젝트, 레벨
    public GameObject summon_skill;
    public GameObject EarnedUi;
    public GameObject skillSysUi;

    public GameObject magicApplyUi; //canvas
    public GameObject skillAbleUi;
    public GameObject CurrentSkillUi;

    public GameObject skillLevelUpUi; //canvas
    public GameObject skillLevelUpUiContent;

    public GameObject tempApplyMagic;
    public Dictionary<int, GameObject> currentMagic = new Dictionary<int, GameObject>(); //적용 되어있는 변수 위치값, 오브젝트

    public MagicPrepare magicPrepare;

    public GameObject MainMagic1;
    public GameObject DebugMagic2;
    public GameObject DebugMagic3;

    public GameObject Earned1;
    public GameObject Earned2;
    public GameObject Earned3;
    public GameObject Earned4;
    public GameObject Earned5;


    public GameObject currentUi1;
    public GameObject currentUi2;
    public GameObject currentUi3;
    private void Start()
    {      
        EarnedUiSet();
        UseAbleUiApply();
        skillLevelupUi();
    }
    public void skillInit()
    {
        DataController dataController = GameObject.Find("DataController").GetComponent<DataController>();
        if (dataController.gameData.useAbleObj.Count != 0)
        {
            Debug.Log("첫 스킬 등록 완료 상태");
        }
        else
        {
            useAble.Add(MainMagic1, 1);
            Debug.Log("첫 스킬 등록");
        }
        if(dataController.gameData.EarnedAbleObj.Count != 0 || dataController.gameData.useAbleObj.Count == 6) //두번째 항목 스킬 늘어나면 조정
        {
            Debug.Log("획득가능 등록 완료 상태");
        }
        else
        {
            EarnedAble.Add(Earned1, 2);
            EarnedAble.Add(Earned2, 2);
            EarnedAble.Add(Earned3, 2);
            EarnedAble.Add(Earned4, 3);
            EarnedAble.Add(Earned5, 2);
            Debug.Log("획득 가능 스킬 정보 등록");
        }

        magicPrepare = GameObject.Find("MagicPrepare_L").GetComponent<MagicPrepare>();
        if(currentMagic.Count == 0)
        {
            if (magicPrepare.magic[0] != null)
            {
                currentMagic.Add(0, magicPrepare.magic[0]);
            }
            else // 게임 초기 사용자의 스킬 갯수가 3개가 넘지 못할 경우
            {
                currentMagic.Add(0, MainMagic1);
            }
            if (magicPrepare.magic[1] != null)
            {
                currentMagic.Add(1, magicPrepare.magic[1]);
            }
            else
            {
                currentMagic.Add(1, DebugMagic2);
            }
            if (magicPrepare.magic[2] != null)
            {
                currentMagic.Add(2, magicPrepare.magic[2]);
            }
            else
            {
                currentMagic.Add(2, DebugMagic3);
            }
        }else
        {
            Debug.Log("현재 스킬 등록 완료 상태");
        }
    }

    public void EarnedUiSet() //NPC Onclick function
    {
        
        currentUi1 = Instantiate(EarnedUi, this.transform);
        foreach (KeyValuePair<GameObject, int> item in EarnedAble)
        {
            var skillSysTemp = Instantiate(skillSysUi);
            skillSysTemp.transform.SetParent(GameObject.Find("ContentEarned").transform, false); //false 안붙이면 scale이랑 pos가 뒤틀림
            skillSysTemp.GetComponent<SkillSysUi>().Init(item.Key, item.Value);
            LayoutRebuilder.ForceRebuildLayoutImmediate(currentUi1.transform as RectTransform);
            Canvas.ForceUpdateCanvases();
        }
    }

    public void UseAbleUiApply()
    { 
        currentUi2 = Instantiate(magicApplyUi, this.transform);

        foreach (GameObject item in useAble.Keys)
        {
            var skillAbletemp = Instantiate(skillAbleUi);
            skillAbletemp.transform.SetParent(GameObject.Find("ContentUseAble").transform, false);
            skillAbletemp.GetComponent<SkillUi>().Init(item);
        }
        foreach (KeyValuePair<int, GameObject> item in currentMagic)
        {
            var CurrentSkilltemp = Instantiate(CurrentSkillUi);
            CurrentSkilltemp.transform.SetParent(GameObject.Find("ContentCurrentMagic").transform, false);
            CurrentSkilltemp.GetComponent<CurrentSkillUi>().Init(item.Key, item.Value);
        }
    }
    public void UseAbleUiAdd(GameObject item)
    {
        var skillAbletemp = Instantiate(skillAbleUi);
        skillAbletemp.transform.SetParent(GameObject.Find("ContentUseAble").transform, false);
        skillAbletemp.GetComponent<SkillUi>().Init(item);
    }
    public void skillLevelUpUiAdd(GameObject item)
    {
        var skillupui = Instantiate(skillLevelUpUiContent);
        skillupui.transform.SetParent(GameObject.Find("MagicLevel").transform, false);
        skillupui.GetComponent<SkillLevelUpUi>().Init(item);
    }

    public void skillLevelupUi()
    {
        currentUi3 = Instantiate(skillLevelUpUi, this.transform);
        foreach(GameObject item in useAble.Keys)
        {
            var skillupui = Instantiate(skillLevelUpUiContent);
            skillupui.transform.SetParent(GameObject.Find("MagicLevel").transform, false);
            skillupui.GetComponent<SkillLevelUpUi>().Init(item);
        }
    }

    public void DestroySkillUi()
    {
        Destroy(currentUi1);
        Destroy(currentUi2);
        Destroy(currentUi3);
    }
    public void ReGenerateUi()
    {
        EarnedUiSet();
        UseAbleUiApply();
        skillLevelupUi();
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
         this.transform.localScale = Vector3.zero;
    }
    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
