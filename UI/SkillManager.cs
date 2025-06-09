using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SkillManager : MonoBehaviour
{
    public Dictionary<GameObject, int> kakutokuAble = new Dictionary<GameObject, int> (); //ȹ�氡�� ����        
    public Dictionary<GameObject, int> useAble = new Dictionary<GameObject, int>();      //��밡�� ����  ������Ʈ, ����
    public GameObject summon_skill;
    public GameObject kakutokuUi;
    public GameObject skillSysUi;

    public GameObject magicApplyUi; //canvas
    public GameObject skillAbleUi;
    public GameObject CurrentSkillUi;

    public GameObject skillLevelUpUi; //canvas
    public GameObject skillLevelUpUiContent;

    public GameObject tempApplyMagic;
    public Dictionary<int, GameObject> currentMagic = new Dictionary<int, GameObject>(); //���� �Ǿ��ִ� ���� ��ġ��, ������Ʈ



    public MagicPrepare magicPrepare;  //��ȯ���¿� �������� ���� ������ ������ ���µ����� �� �͸��Ѱ� ����.




    public GameObject MainMagic1;
    public GameObject DebugMagic2;
    public GameObject DebugMagic3;

    public GameObject kakutoku1;
    public GameObject kakutoku2;
    public GameObject kakutoku3;
    public GameObject kakutoku4;
    public GameObject kakutoku5;


    public GameObject currentUi1;
    public GameObject currentUi2;
    public GameObject currentUi3;
    private void Start()
    {      
        KakutokuUiSet();
        UseAbleUiApply();
        skillLevelupUi();
    }
    public void skillInit()
    {
        DataController dataController = GameObject.Find("DataController").GetComponent<DataController>();
        if (dataController.gameData.useAbleObj.Count != 0)
        {
            Debug.Log("ù ��ų ��� �̹� �Ϸ�");
        }
        else
        {
            useAble.Add(MainMagic1, 1);
            Debug.Log("ù ��ų ���");
        }
        if(dataController.gameData.kakutokuAbleObj.Count != 0 || dataController.gameData.useAbleObj.Count == 6) //�ι�° �׸� ��ų �þ�� ����
        {
            Debug.Log("ȹ�氡�� �̹� ��� �Ϸ�");
        }
        else
        {
            kakutokuAble.Add(kakutoku1, 2);
            kakutokuAble.Add(kakutoku2, 2);
            kakutokuAble.Add(kakutoku3, 2);
            kakutokuAble.Add(kakutoku4, 3);
            kakutokuAble.Add(kakutoku5, 2);
            Debug.Log("ȹ�� ���� ��ų ���� ���");
        }



        magicPrepare = GameObject.Find("MagicPrepare_L").GetComponent<MagicPrepare>();
        if(currentMagic.Count == 0)
        {
            if (magicPrepare.magic[0] != null)
            {
                currentMagic.Add(0, magicPrepare.magic[0]);
            }
            else // ���� �ʱ� ������� ��ų ������ 3���� ���� ���� ���
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
            Debug.Log("���� ��ų �̹� ��� �Ϸ�");
        }
       


        
    }

    public void KakutokuUiSet() //NPC Onclick function
    {
        
        currentUi1 = Instantiate(kakutokuUi, this.transform);
        foreach (KeyValuePair<GameObject, int> item in kakutokuAble)
        {
            var skillSysTemp = Instantiate(skillSysUi);
            skillSysTemp.transform.SetParent(GameObject.Find("ContentKakutoku").transform, false); //false �Ⱥ��̸� scale�̶� pos ���׹��� 
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

        KakutokuUiSet();
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
